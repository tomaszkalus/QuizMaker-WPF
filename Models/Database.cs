using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizMaker.Models
{
    class Database
    {
        private readonly List<Quiz> _quizes;

        public Database(List<Quiz> quizes)
        {
            _quizes = quizes;
        }

        public void AddQuiz(Quiz quiz)
        {
            _quizes.Add(quiz);
        }
        public void DeleteQuiz(int id)
        {
            try
            {
                _quizes.Remove(_quizes.Find(x => x.QuizID == id));
            }
            catch(ArgumentNullException e)
            {
                throw (new ArgumentNullException());
            }
        }
    
    }
}
