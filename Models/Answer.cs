using QuizMaker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizMaker.Models
{
    class Answer
    {
        public int AnswerID { get; }
        public string Text;
        public Boolean IsCorrect;
        private int Field;

        public Answer(int answerId, string text, bool isCorrect, int field)
        {
            AnswerID = answerId;
            Text = text;
            IsCorrect = isCorrect;
            Field = field;
        }
    }
}

