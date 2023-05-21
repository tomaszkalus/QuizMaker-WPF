using QuizMaker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizMaker.DB.Repositories
{
    internal interface IQuestionRepository
    {
        public void AddQuestion(Question question, int quizId);
        public void UpdateQuestion(Question question);
        public void DeleteQuestion(Question question);
        public Question GetQuestionByID(int questionID);
    }
}
