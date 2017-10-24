using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CosmeticFinder.Data;
using CosmeticFinder.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CosmeticFinder.Controllers
{
    public class CosmeticFieldController : Controller
    {
        //Cosmetic Field controller is my all purpose controller for ALL my categories

        private CosmeticDbContext context;

        public CosmeticFieldController(CosmeticDbContext dbContext)
        {
            context = dbContext;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {

            //fill database with all categories you want, then comment out when you run it.
            //Keep this just in case you have to drop the database'

            return View();
        }



}
}
