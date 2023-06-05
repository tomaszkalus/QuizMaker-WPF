using QuizMaker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizMaker.Stores
{
    public class QuizStore
    {
        private Quiz _currentQuiz;

        public Quiz CurrentQuiz
        {
            get { return _currentQuiz; }
            set { _currentQuiz = value; }
        }

    }
}
