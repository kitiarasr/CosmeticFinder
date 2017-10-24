using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CosmeticFinder.Data;
using CosmeticFinder.Models;
using Microsoft.EntityFrameworkCore;
using CosmeticFinder.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CosmeticFinder.Controllers
{
    public class CosmeticController : Controller
    {

        private CosmeticDbContext context;

        public CosmeticController(CosmeticDbContext dbContext)
        {
            context = dbContext;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
 
            /*
                Color newColor = new Color
                {
                    Name = "Pink"

                };
 
                Color newColor2 = new Color
                {
                    Name = "Red"

                };
                context.Colors.Add(newColor);
                context.Colors.Add(newColor2);

            //////////////////////////////////////////////

             Finish newFinish = new Finish
            {
                Name = "Glittery"

            };

            Finish newFinish2 = new Finish
            {
                Name = "Matte"

            };
           
            context.Finishs.Add(newFinish);
            context.Finishs.Add(newFinish2);

            ////////////////////////////////////////////////
            Formulation newFormulation = new Formulation
            {
                Name = "Liquid"

            };
            Formulation newFormulation2 = new Formulation
            {
                Name = "Cream"

            };
            context.Formulations.Add(newFormulation);
            context.Formulations.Add(newFormulation2);

            /////////////////////////////////////////////////
            Rating newRating = new Rating
            {
                ratingScore = 4.5

            };
            Rating newRating2 = new Rating
            {
                ratingScore = 5

            };
            context.Ratings.Add(newRating);
            context.Ratings.Add(newRating2);

            /////////////////////////////////////////////////

            SkinType newSkinType = new SkinType
            {
                Name = "Oily"

            };
            SkinType newSkinType2 = new SkinType
            {
                Name = "Dry"

            };
            context.SkinTypes.Add(newSkinType);
            context.SkinTypes.Add(newSkinType2);

            /////////////////////////////////////////////////

            context.SaveChanges();*/

            IList<Cosmetic> cosmetics = context.Cosmetics
                .Include(f => f.Finish)
                .Include(c => c.Color)
                .Include(c => c.Formulation)
                .Include(r => r.Rating)
                .Include(s => s.SkinType)
                .ToList();
   

            return View(cosmetics);
        }

        [HttpGet]
        public IActionResult Add()
        {

            AddCosmeticViewModel addCosmeticVM = new AddCosmeticViewModel(context);

            //be able to add new cosmetic to db list of cosmetics.
            return View(addCosmeticVM);
        }
        [HttpPost]
        public IActionResult Add(AddCosmeticViewModel addCosmeticVM)
        {
            if (ModelState.IsValid)// && addCheeseViewModel.CategoryID != 0)
            {
                if (addCosmeticVM.ColorID != 0 || addCosmeticVM.FormulationID != 0 || addCosmeticVM.FinishID != 0 || addCosmeticVM.RatingID != 0 || addCosmeticVM.SkinTypeID != 0)
                {
                    Cosmetic newCosmetic = new Cosmetic
                    {
                        //fish for all these ids in database
                        Name = addCosmeticVM.Name,
                        Description = addCosmeticVM.Description,
                        Color = context.Colors.Single(c => c.ID == addCosmeticVM.ColorID),
                        Finish = context.Finishs.Single(f => f.ID == addCosmeticVM.FinishID),
                        Formulation = context.Formulations.Single(f => f.ID == addCosmeticVM.FormulationID),
                        Rating = context.Ratings.Single(r => r.ID == addCosmeticVM.RatingID),
                        SkinType = context.SkinTypes.Single(s => s.ID == addCosmeticVM.SkinTypeID)

                    };

                    context.Cosmetics.Add(newCosmetic);
                    context.SaveChanges();

                    return Redirect("/Cosmetic");
                }
            }

            return View(addCosmeticVM);

        }
    }
}
