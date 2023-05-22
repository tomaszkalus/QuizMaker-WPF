using QuizMaker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizMaker.DB.Repositories
{
    public interface IQuizRepository
    {
        public void AddQuiz(Quiz quiz);
        public void DeleteQuiz(Quiz quiz);

        public List<Quiz> GetAllQuizes();
    }
}
