using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CosmeticFinder.Models
{
    public class CosmeticBag
    {
        public int ID { get; set; }   
        public int userID { get; set; }
        public string Name { get; set; }
        public List<CosmeticBag_Items> cosmetics_items { get; set; }// = new List<CosmeticBag_Items> ();

    }
}
