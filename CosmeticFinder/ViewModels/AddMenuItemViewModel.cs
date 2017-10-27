using CosmeticFinder.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CosmeticFinder.ViewModels
{
    public class AddMenuItemViewModel
    {
        //used to render and process the form to add
        //a new item to given menu
        public int cosmeticID { get; set; }
        public int cosmeticBagID { get; set; }
        public CosmeticBag CosmeticBag { get; set; }
        public List<SelectListItem> Cosmetics { get; set; }


        public AddMenuItemViewModel()
        {

        }

        public AddMenuItemViewModel(CosmeticBag cosmeticBag, IEnumerable<Cosmetic> ch)
        {
            CosmeticBag = cosmeticBag;
            Cosmetics = new List<SelectListItem>();

            foreach (var cosmetic in ch)
            {
                Cosmetics.Add(new SelectListItem
                {
                    Value = cosmetic.ID.ToString(),
                    Text = cosmetic.Name

                });
            }

        }
    }
}
