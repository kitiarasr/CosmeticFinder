using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CosmeticFinder.Models
{
    //I think this will suit my purpose as the category
    public class CosmeticField
    {
        public int ID { get; set; }
       // public string Name { get; set; } //every field needs a name
        IList<Cosmetic> Cosmetics { get; set; } //every field needs a cosmetic to go with it
       // private static int nextId = 1;

        public string Value { get; set; }

        public CosmeticField()  //constructor representing ALL cosmetics
        {
         //   ID = nextId;
         //   nextId++;

        }

        public CosmeticField(string value) : this()
        {
            Value = value;   //this is what is being searched
        }

        //does case-insensitive search
        public bool Contains(string testValue)
        {
            return Value.ToLower().Contains(testValue.ToLower());
            //VALUE IS BLANK. VALUE I WANT IS ACTUALLY IN TEXT VARIABLE. WHY IS THIS?
        }


        public override string ToString()
        {
            return Value;
        }

        public override bool Equals(object obj)
        {
            if(obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            return (obj as CosmeticField).ID == ID;
        }

        public override int GetHashCode()
        {
            return ID;
        }
    }
}
