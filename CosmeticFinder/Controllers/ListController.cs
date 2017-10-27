using CosmeticFinder.Data;
using CosmeticFinder.Models;
using CosmeticFinder.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CosmeticFinder.Controllers
{
    public class ListController : Controller
    {
        private CosmeticDbContext context;

        public ListController(CosmeticDbContext dbContext)
        {
            context = dbContext;
        }

        public IActionResult Index()
        {
            CosmeticListViewModel listVM = new CosmeticListViewModel();
            listVM.Title = "View Cosmetic Categories";

            return View(listVM);
        }

        public IActionResult Values(CosmeticFieldType column)
        {
            if (column.Equals(CosmeticFieldType.All))
            {
                SearchCosmeticsViewModel searchVM = new SearchCosmeticsViewModel();
                searchVM.Cosmetics = context.Cosmetics.ToList();
                searchVM.Title = "All Cosmetics";
                return View("Cosmetics", searchVM);
            }
            else
            {
                CosmeticListViewModel listVM = new CosmeticListViewModel();

                IEnumerable<CosmeticField> fields;
               // List<CosmeticField> fields;

                switch (column)
                {
    
                    case CosmeticFieldType.Finish:
                        fields = context.Finishs.ToList().Cast<CosmeticField>();
                        break;
                    case CosmeticFieldType.Formulation:
                        fields = context.Formulations.ToList().Cast<CosmeticField>();
                        break;
                    case CosmeticFieldType.Rating:
                        fields = context.Ratings.ToList().Cast<CosmeticField>();
                        break;
                    case CosmeticFieldType.SkinType:
                        fields = context.SkinTypes.ToList().Cast<CosmeticField>();
                        break;

                    case CosmeticFieldType.Color:
                    default:
                        fields = context.Colors.ToList().Cast<CosmeticField>();
                        break;
                }

                listVM.Fields = fields;
                listVM.Title = "All " + column + " Values";
                listVM.Column = column;

                return View(listVM);
            }
        }

        // Lists Jobs with a given field matching a given value
        public IActionResult Cosmetics(CosmeticFieldType column, string value)
        {
            SearchCosmeticsViewModel searchVM = new SearchCosmeticsViewModel();
            searchVM.Cosmetics = context.FindByColumnAndValue(column, value);
            searchVM.Title = "Cosmetics with " + column + ": " + value;

            return View(searchVM);
        }
    }
}
