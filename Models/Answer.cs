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

        private static int nrOfInstances = 0;
        private readonly int _answerId;
        public int AnswerId => _answerId;


        public string Text;
        public Boolean IsCorrect;
        public int Field;

        public Answer(string text, bool isCorrect, int field)
        {
            // Assigning a new unique ID for each answer
            _answerId = Answer.nrOfInstances;
            Answer.nrOfInstances++;

            Text = text;
            IsCorrect = isCorrect;
            Field = field;
        }
        public override string ToString()
        {
            return $"{_answerId.ToString()} - {Text} - {IsCorrect.ToString()} - {Field.ToString()}";
        }
    }
}

