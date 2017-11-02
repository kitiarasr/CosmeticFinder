using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CosmeticFinder.Models
{
    public class Responses
    {
        public int AnswersID { get; set; }
        public int QuestionID { get; set; } //every answer is associated with a question
        public string AnswerResponse { get; set; }
    }
}
