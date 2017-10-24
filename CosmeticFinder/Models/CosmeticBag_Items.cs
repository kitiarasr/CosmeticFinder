using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CosmeticFinder.Models
{
    public class CosmeticBag_Items  //my join class of cosmetic and cosmetic Bag to make wishlist
    {
        public int  CosmeticID { get; set; }
        public Cosmetic Cosmetic { get; set; }
        public int CosmeticBagID { get; set; }
        public CosmeticBag CosmeticBag { get; set; }

    }
}
