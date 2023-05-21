using QuizMaker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizMaker.DB.Repositories
{
    public interface IAnswersRepository
    {
        public void AddAnswer(Answer answer, int questionId);
        public void UpdateAnswer(Answer answer);
        public void DeleteAnswer(Answer answer);
        public List<Answer> GetAnswersByQuestionID(int questionID);

    }
}
