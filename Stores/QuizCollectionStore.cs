using QuizMaker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizMaker.Stores
{
    public class QuizCollectionStore
    {
        private QuizCollection _currentQuizCollection;

        public QuizCollection CurrentQuizCollection
        {
            get { return _currentQuizCollection; }
            set { _currentQuizCollection = value; }
        }
    }
}
