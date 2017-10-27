using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CosmeticFinder.Models
{
    public class Questions
    {
        public int QuestionsID { get; set; }
        //Fill this list of answers with whats in db according to QUESTION ID
        public List<Answers> Answers { get; set; } = new List<Answers>();
        public int choiceID { get; set; }  //choice user makes. ViewModel Stuff only
        static public int QuestionNumber { get; set; }
        public string QuestionText { get; set; }

        public Questions()
        {
            QuestionNumber = QuestionsID;
        }
    }
}
