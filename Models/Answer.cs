using QuizMaker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizMaker.Models
{
    public class Answer
    {
        public int? AnswerID { get; }
        public string Text;
        public Boolean IsCorrect;
        public int Field;

        public Answer(string text, bool isCorrect, int field, int? answerId = null)
        {
            AnswerID = answerId;
            Text = text;
            IsCorrect = isCorrect;
            Field = field;
        }
        public override string ToString()
        {
            return $"{AnswerID.ToString()} - {Text} - {IsCorrect.ToString()} - {Field.ToString()}";
        }
    }
}

