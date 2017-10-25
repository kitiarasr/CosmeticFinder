using CosmeticFinder.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CosmeticFinder.ViewModels
{
    public class SearchCosmeticsViewModel : BaseViewModel
    {

        public List<Cosmetic> Cosmetics { get; set; }

        public CosmeticFieldType Column { get; set; } = CosmeticFieldType.All;


        [Display(Name = "Keyword:")]
        public string Value { get; set; } = "";

    }
}
