using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizMaker.Models
{
    public class Question
    {
        public Question(string text, List<Answer> answers, int order, int? questionID = null)
        {
            QuestionID = questionID;
            Text = text;
            Answers = answers;
            Order = order;
        }

        public int? QuestionID { get; }
        public string Text { get; }
        public List<Answer> Answers { get;}
        public int Order { get;}
    }
}
