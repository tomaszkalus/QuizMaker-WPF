using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizMaker.Models
{
    public class Quiz
    {
        private readonly List<Question> _questions;

        public Quiz(List<Question> questions, int quizID, string quizName)
        {
            _questions = questions;
            QuizID = quizID;
            QuizName = quizName;
        }

        public int QuizID { get; }
        public string QuizName { get; set; }

        public int NumberOfQuestions => _questions.Count;

    }
}
