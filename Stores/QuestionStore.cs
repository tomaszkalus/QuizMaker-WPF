using QuizMaker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizMaker.Stores
{
    public class QuestionStore
    {
        private Question _currentQuestion;

        public Question CurrentQuestion 
        {
            get => _currentQuestion;
            set
            {
                _currentQuestion = value;
            }
        }

    }
}
