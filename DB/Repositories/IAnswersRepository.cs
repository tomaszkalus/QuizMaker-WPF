using QuizMaker.Models;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizMaker.DB.Repositories
{
    public interface IAnswersRepository
    {
        public void AddAnswer(Answer answer, int questionId, SQLiteTransaction transaction);
        public void UpdateAnswer(Answer answer, SQLiteTransaction transaction);
        public List<Answer> GetAnswersByQuestionID(int questionID);

    }
}
