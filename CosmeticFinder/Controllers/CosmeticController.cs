﻿using System;
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
            Questions question1 = new Questions()
            {
                QuestionText = "What color eyes do you have?"
            };

            Questions question2 = new Questions()
            {
                QuestionText = "What is your skin Tone?"
            };

           
            Answers answer1 = new Answers()
            {
                QuestionID = question1.QuestionsID,
                AnswerLetter = "A",
                AnswerText = "Brown",
               // AnswerResponse = "Golden eyeshadow shades would suite you best"
            };
            Answers answer2 = new Answers()
            {
                QuestionID = question2.QuestionsID,
                AnswerLetter = "B",
                AnswerText = "Blue",
              //  AnswerResponse = "Red eyeshadow would be the bomb dot com!"
            };
            context.Questions.Add(question1);
            context.Questions.Add(question2);
            context.Answers.Add(answer1);
            context.Answers.Add(answer2);*/


          //  context.SaveChanges();



            /*     Color newColor = new Color
                 {
                     Value = "Pink"


                 };

                 Color newColor2 = new Color
                 {
                     Value = "Red"

                 };
                 context.Colors.Add(newColor);
                 context.Colors.Add(newColor2);

             //////////////////////////////////////////////

              Finish newFinish = new Finish
             {
                 Value = "Glittery"

             };

             Finish newFinish2 = new Finish
             {
                 Value = "Matte"

             };

             context.Finishs.Add(newFinish);
             context.Finishs.Add(newFinish2);

             ////////////////////////////////////////////////
             Formulation newFormulation = new Formulation
             {
                 Value = "Liquid"

             };
             Formulation newFormulation2 = new Formulation
             {
                 Value = "Cream"

             };
             context.Formulations.Add(newFormulation);
             context.Formulations.Add(newFormulation2);

             /////////////////////////////////////////////////
             Rating newRating = new Rating
             {
                 Value = "4.5"

             };
             Rating newRating2 = new Rating
             {
                 Value = "5"

             };
             context.Ratings.Add(newRating);
             context.Ratings.Add(newRating2);

             /////////////////////////////////////////////////

             SkinType newSkinType = new SkinType
             {
                 Value = "Oily"

             };
             SkinType newSkinType2 = new SkinType
             {
                 Value = "Dry"

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
            //probably have to include the actual objects from db lists instead of references from objects from cosmetics themselves
   

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
               //if (addCosmeticVM.ColorID != 0 && addCosmeticVM.FormulationID != 0 && addCosmeticVM.FinishID != 0 && addCosmeticVM.RatingID != 0 && addCosmeticVM.SkinTypeID != 0)
                //{
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
              //  }
            }

            return View(addCosmeticVM);

        }
    }
}
