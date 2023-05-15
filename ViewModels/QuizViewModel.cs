using QuizMaker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizMaker.ViewModels
{
    public class QuizViewModel : ViewModelBase
    {
        private readonly Quiz _quiz;
        public string QuizName => _quiz.QuizName;
        public string NumberOfQuestions => _quiz.NumberOfQuestions.ToString();

        public QuizViewModel(Quiz quiz)
        {
            _quiz = quiz;
        }

    }
}
