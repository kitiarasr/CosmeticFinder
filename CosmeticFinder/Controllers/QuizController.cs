using CosmeticFinder.Data;
using CosmeticFinder.ViewModels;
using Microsoft.AspNetCore.Mvc;
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
            IDictionary<int, string> AnswerHolder = new Dictionary<int, string>();
            ViewQuizViewModel viewQuiz = new ViewQuizViewModel
            {

            };
            
            return View();

        }
        [HttpPost]
        public IActionResult Index(ViewQuizViewModel viewQuizVM)
        {

           // context.Questions = viewQuizVM.Questions;
            return Redirect("/Results");

        }
    }
}
