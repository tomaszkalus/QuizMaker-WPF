using QuizMaker.Models;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizMaker.DB.Repositories
{
    public class QuizRepository
    {
        public long AddQuiz(SQLiteConnection connection, Quiz quiz)
        {
            string addQuizQuery = "INSERT INTO Quiz(Quiz_Name) VALUES (@quiz_name)";

            using (SQLiteCommand addQuizCommand = new SQLiteCommand(addQuizQuery, connection))
            {
                addQuizCommand.Parameters.AddWithValue("@quiz_name", quiz.QuizName);
                addQuizCommand.ExecuteNonQuery();
            }

            return connection.LastInsertRowId;
        }


        public List<Quiz> GetAllQuizes(SQLiteConnection connection)
        {
            List<Quiz> quizes = new List<Quiz>();

            string getQuestionCommand = "SELECT * from Quiz";

            using (SQLiteCommand questionCommand = new SQLiteCommand(getQuestionCommand, connection))
            {
                QuestionRepository questionRepository = new QuestionRepository();
                int quizId;
                string quizName;
                List<Question> questions;
                SQLiteDataReader quizReader = questionCommand.ExecuteReader();
                while (quizReader.Read())
                {
                    quizId = (int)(long)quizReader["Quiz_ID"];
                    quizName = (string)quizReader["Quiz_Name"];
                    questions = questionRepository.GetQuestionByQuizId(quizId, connection);
                    quizes.Add(new Quiz(questions, quizName));
                }
            }

            connection.Close();
            return quizes;

        }

        public void SaveQuizesToDatabase(SQLiteConnection connection, QuizCollection quizCollection)
        {
            QuestionRepository questionRepository = new QuestionRepository();

            foreach (var quiz in quizCollection.GetAllQuizes())
            {
                long quizId = AddQuiz(connection, quiz);

                foreach (var question in quiz.GetAllQuestions())
                {
                    questionRepository.AddQuestion(connection, question, quizId);

                }
            }
            connection.Close();

        }
    }
}
