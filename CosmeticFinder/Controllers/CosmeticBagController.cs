using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CosmeticFinder.Data;
using CosmeticFinder.Models;
using CosmeticFinder.ViewModels;
using Microsoft.EntityFrameworkCore;

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

        [HttpGet]
        public IActionResult ViewCosmeticBag(int id)
        {
            CosmeticBag getBag = context.CosmeticBags.Where(a => a.ID == id).Single();


            List<CosmeticBag_Items> items = context
                .CosmeticBag_Items
                .Include(cb => cb.Cosmetic)
                .Where(cb => cb.CosmeticBagID == id)
                .ToList();

            ViewCosmeticBagViewModel viewCBagVM = new ViewCosmeticBagViewModel();
            viewCBagVM.CosmeticBag = getBag;
            viewCBagVM.Items = items;


            return View(viewCBagVM);
        }
        [HttpGet]
        public IActionResult AddItem(int id)
        {
            IEnumerable<Cosmetic> cosmetics = context.Cosmetics.ToList();

            CosmeticBag cosB = context.CosmeticBags.Where(a => a.ID == id).Single();

            AddMenuItemViewModel cosmeticBagItemVM = new AddMenuItemViewModel(cosB, cosmetics);

            return View(cosmeticBagItemVM);
        }

        [HttpPost]
        public IActionResult AddItem(AddMenuItemViewModel cosmeticBagItemVM)
        {

            IList<CosmeticBag_Items> existingItems = context.CosmeticBag_Items
            .Where(cm => cm.CosmeticID == cosmeticBagItemVM.cosmeticID)
            .Where(cm => cm.CosmeticBagID == cosmeticBagItemVM.cosmeticBagID).ToList();

            if (existingItems.Count == 0)
            {
                CosmeticBag_Items cosmeticBag = new CosmeticBag_Items
                {
                    CosmeticBagID = cosmeticBagItemVM.cosmeticBagID,
                    CosmeticID = cosmeticBagItemVM.cosmeticID,
           
                };
                context.CosmeticBag_Items.Add(cosmeticBag);
                context.SaveChanges();
            }

            return Redirect("/CosmeticBag/ViewCosmeticBag/" + cosmeticBagItemVM.cosmeticBagID);
        }


    }
}
