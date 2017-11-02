using CosmeticFinder.Data;
using CosmeticFinder.Models;
using CosmeticFinder.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CosmeticFinder.Controllers
{
    public class QuizController : Controller
    {
        private CosmeticDbContext context;

        public QuizController(CosmeticDbContext dbContext)
        {
            context = dbContext;
        }
        [HttpGet]
        public IActionResult Index()
        {
            //populate choiceHolder dictionary in viewQuizViewModel with just question IDs and ommit or submit zero values for 
            //answerIDs (choices user makes in forms for each question)
            //   Dictionary<int, int> choiceHolder = new Dictionary<int, int>();
            //   List<int> choiceHolder = new List<int>(5);


            /* choiceHolder.Add(0); //1 through 4 correspond to ids of questions, the 0s correspond to the choiceID returned from form.
             choiceHolder.Add(0);
             choiceHolder.Add(0);
             choiceHolder.Add(0);*/

            ViewQuizViewModel viewQuiz = new ViewQuizViewModel //packet
            {
                //when i send package to view, i have to somehow keep values of keys (ids) intact
                QuestionList = context.Questions.ToList()
            };
            
            return View(viewQuiz);

        }
        [HttpPost]
        public IActionResult Index(ViewQuizViewModel viewQuizVM)
        {
            foreach (var choice in viewQuizVM.ChoiceHolder) // choiceholder holds dictionary of quiestion id and answer id
            {
              //  Answers answer = context.Answers.Where(a => a.AnswersID == choice.Value).Single();
              //  Responses response = context.Responses.Where(r => r.QuestionID == choice.Value).Single();
              //  viewQuizVM.AnswerHolder.Add(1, response.AnswerResponse);
                //keep quiz simple and just have strings.. problem is I can't dicipher between a foundation
                //makup and a lipstick makeup.
                //question1 pertains to skin tone. I query for light, medium, dark makeups
                //question2   
                //question 3 ask for eye color, pertains to eyeshadow color
                //question 4 
            }
            return Redirect("/Results");

        }
    }
}
