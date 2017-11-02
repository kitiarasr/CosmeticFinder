using CosmeticFinder.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CosmeticFinder.ViewModels
{
    public class ViewQuizViewModel
    {
        public Questions Questions { get; set; }   //Question object reference
        public int QuestionID { get; set; }
        // public IDictionary<int, int> ChoiceHolder = new Dictionary<int, int>(); //every questionid will pertain to one chosen answer
        public List<int> ChoiceHolder = new List<int>(5);                                                                      // public string AnswerResponse { get; set; }
                                                                                                                               // public IDictionary<int, string> AnswerHolder = new Dictionary<int, string>();
       // public List<int> AnswerHolder = new List<int>(5);
        public List<Questions> QuestionList;


        //populate for the number of questions that I have
        //will hold all answers chosen by user in order
        //  public List<int> AnswerIDs { get; set; }  

        //populate for the number of answers FOR the number of questions
        //this is a list of lists of selectListItems. Each selectListItem List is associated with a question.

        // public List<List<SelectListItem>> Answers { get; set; } = new List<List<SelectListItem>>();

        //Summary:
        //for number of questions in list, display answers assiociated with question, and collect answerID
        //for each question... putting answerID into a list of answerIDs.




    }
}
