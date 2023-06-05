using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizMaker.Models
{
    public class Question
    {
        private static int nrOfInstances = 0;
        private readonly int _questionId;
        public int QuestionId => _questionId;

        public Question(string text, List<Answer> answers, int order)
        {
            // Assigning a new unique ID for each question
            _questionId = Question.nrOfInstances;
            Question.nrOfInstances++;

            Text = text;
            Answers = answers;
            Order = order;
        }

        public string Text { get; }
        public List<Answer> Answers { get;}
        public int Order { get;}

        internal bool Conflicts(Question question)
        {
            if (question.Text == Text)
            {
                return false;
            }
            return true;
        }


    }
}
