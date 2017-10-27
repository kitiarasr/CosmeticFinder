using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CosmeticFinder.Models
{
    public class Answers
    {
        public int AnswersID { get; set; }
        public int QuestionID { get; set; } //every answer is associated with a question
        public string AnswerLetter { get; set; }
        public string AnswerText { get; set; }
    }
}
