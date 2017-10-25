using CosmeticFinder.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CosmeticFinder.Data;

namespace CosmeticFinder.ViewModels
{
    public class AddCosmeticViewModel
    {
        //COMING SOOON
        public string Name { get; set; }
        public string Description { get; set; }
        //   Bitmap Picture { get; set; }
        public int ColorID { set; get; }  //this id will be one (cosmetic) to many colors.
        public List<SelectListItem> Colors { get; set; } = new List<SelectListItem>();

        public int SkinTypeID { get; set; }
        public List<SelectListItem> SkinTypes { get; set; } = new List<SelectListItem>();

        public int FormulationID { get; set; }
        public List<SelectListItem> Formulations { get; set; } = new List<SelectListItem>();

        public int RatingID { get; set; }
        public List<SelectListItem> Ratings { get; set; } = new List<SelectListItem>();

        public int FinishID { get; set; }
        public List<SelectListItem> Finishs { get; set; } = new List<SelectListItem>();


        public AddCosmeticViewModel() { }

        public AddCosmeticViewModel(CosmeticDbContext context)
        {

           foreach(var color in context.Colors.ToList())
            {

                Colors.Add(new SelectListItem
                {
                    Value = color.ID.ToString(),
                    Text = color.Value
                });
            }

            foreach (var skinType in context.SkinTypes.ToList())
            {

                SkinTypes.Add(new SelectListItem
                {
                    Value = skinType.ID.ToString(),
                    Text = skinType.Value
                });
            }

            foreach (var formulation in context.Formulations.ToList())
            {

                Formulations.Add(new SelectListItem
                {
                    Value = formulation.ID.ToString(),
                    Text = formulation.Value
                });
            }

            foreach (var rating in context.Ratings.ToList())
            {

                Ratings.Add(new SelectListItem
                {
                    Value = rating.ID.ToString(),
                    Text = rating.Value
                });
            }

            foreach (var finish in context.Finishs.ToList())
            {

                Finishs.Add(new SelectListItem
                {
                    Value = finish.ID.ToString(),
                    Text = finish.Value
                });
            }


        }
    }
}
