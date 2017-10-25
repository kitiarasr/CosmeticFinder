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
    public class SearchController : Controller
    {

        private CosmeticDbContext context;

        public SearchController(CosmeticDbContext dbContext)
        {
            context = dbContext;
        }
 
        public IActionResult Index()
        {
            SearchCosmeticsViewModel VM = new SearchCosmeticsViewModel();

            return View(VM);

        }
        public IActionResult Results(SearchCosmeticsViewModel searchCVM)
        {
           // searchCVM.Column = CosmeticFieldType.All;

            //   if (ModelState.IsValid)
            if (searchCVM.Value == null)
            {
                searchCVM.Value = "";
            }
            if (searchCVM.Column.Equals(CosmeticFieldType.All) || searchCVM.Value.Equals(""))
            {
                searchCVM.Cosmetics = context.FindByValue(searchCVM.Value);
            }
            else
            {
                searchCVM.Cosmetics = context.FindByColumnAndValue(searchCVM.Column, searchCVM.Value);
            }

           // searchCVM.Title = "Search";

            return View("Index", searchCVM);
        }
    }
    
}
