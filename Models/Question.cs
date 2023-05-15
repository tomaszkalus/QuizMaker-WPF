using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizMaker.Models
{
    public class Question
    {
        public Question(int questionID, string text, Answer[] answers, int order)
        {
            QuestionID = questionID;
            Text = text;
            Answers = answers;
            Order = order;
        }


        public int QuestionID { get; }
        public string Text {get; set;}
        public Answer[] Answers { get; set;}
        public int Order { get; set;}
    }
}
