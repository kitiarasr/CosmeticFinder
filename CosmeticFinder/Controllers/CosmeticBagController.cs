using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CosmeticFinder.Data;
using CosmeticFinder.Models;
using CosmeticFinder.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CosmeticFinder.Controllers
{
    public class CosmeticBagController : Controller
    {
        // GET: /<controller>/

        private CosmeticDbContext context;

        public CosmeticBagController(CosmeticDbContext dbContext)
        {
            context = dbContext;
        }
        public IActionResult Index() //what viewers will see upon clicking my account. wishlist.
        {
            List<CosmeticBag> CosmeticBags = context.CosmeticBags.ToList();

          //  ViewBag.Title = "New Menu";

            return View(CosmeticBags);
        }
        [HttpGet]
        public IActionResult Add()
        {
            AddCosmeticBagViewModel ViewCBag = new AddCosmeticBagViewModel();

            return View(ViewCBag);
        }

        [HttpPost]
        public IActionResult Add(AddCosmeticBagViewModel ViewCBag)
        {
            if (ModelState.IsValid)
            {

                CosmeticBag newBag = new CosmeticBag
                {
                    Name = ViewCBag.Name
                };
                context.CosmeticBags.Add(newBag);
     
                context.SaveChanges();

                return Redirect("/CosmeticBag/ViewCosmeticBag/" + newBag.ID);
            }
            return View(ViewCBag); //pass in object so view has somethign to work with

        }
    }
}
