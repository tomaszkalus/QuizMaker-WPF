using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace QuizMaker.Models
{
    public class QuizCollection
    {
        private readonly List<Quiz> _quizes;

        public QuizCollection(List<Quiz> quizes)
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
                _quizes.Remove(_quizes.Find(x => x.QuizId == id));
            }
            catch(ArgumentNullException e)
            {
                throw (new ArgumentNullException());
            }
        }

        public IEnumerable<Quiz> GetAllQuizes() 
        {
            return _quizes;
        }

        public Quiz GetQuizById(int id)
        {
            return _quizes.Find(x => x.QuizId == id);
        }

        public bool Conflicts(string quizName)
        {
            foreach (Quiz quiz in _quizes)
            {
                if (quiz.QuizName == quizName)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
