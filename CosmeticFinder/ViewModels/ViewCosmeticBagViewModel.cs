using CosmeticFinder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CosmeticFinder.ViewModels
{
    public class ViewCosmeticBagViewModel
    {
        public CosmeticBag CosmeticBag { get; set; }
        public List<CosmeticBag_Items> Items { get; set; }
    }
}
