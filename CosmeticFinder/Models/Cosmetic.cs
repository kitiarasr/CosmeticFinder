using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CosmeticFinder.Models
{
    public class Cosmetic
    {
        public int ID { get; set; }
     //   public static int nextID = 1;
        public string Name { get; set; }
        public string Description { get; set; }
        //   Bitmap Picture { get; set; }
        public int ColorID { set; get; }  //this id will be one (cosmetic) to many colors.
        public Color Color { get; set; }

        public int SkinTypeID { get; set; }
        public SkinType SkinType { get; set; }

        public int FormulationID { get; set; }
        public Formulation Formulation { get; set; }

        public int RatingID { get; set; }
        public Rating Rating { get; set; } //every field needs a cosmetic to go with it

        public int FinishID { get; set; }
        public Finish Finish { get; set; } //every field needs a cosmetic to go with it

        List <CosmeticBag_Items> cosmetic_items { get; set; } // = new <CosmeticBag_Items>();





      /*  public Cosmetic()
        {
            ID = nextID;
            nextID++;
        }*/
    }
}
