using QuizMaker.Models;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizMaker.DB.Repositories
{
    public class QuizRepository : IQuizRepository
    {
        private readonly string _connectionString;

        public QuizRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void AddQuiz(Quiz quiz)
        {
            using (SQLiteConnection connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();

                string addQuizQuery = "INSERT INTO quiz(quiz_name) VALUES (@quiz_name)";

                using (SQLiteCommand addQuizCommand = new SQLiteCommand(addQuizQuery, connection))
                {
                    addQuizCommand.Parameters.AddWithValue("@quiz_name", quiz.QuizName);
                    addQuizCommand.ExecuteNonQuery();
                }
            }
        }

        //public void DeleteQuiz(Quiz quiz)
        //{
        //    using (SQLiteConnection connection = new SQLiteConnection(_connectionString))
        //    {
        //        connection.Open();

        //        using (SQLiteCommand pragmaCommand = new SQLiteCommand("PRAGMA foreign_keys=on", connection))
        //        {
        //            pragmaCommand.ExecuteNonQuery();
        //        }

        //        string questionDeleteQuery = "DELETE FROM quiz WHERE quiz_id = @Id";
        //        using (SQLiteCommand command = new SQLiteCommand(questionDeleteQuery, connection))
        //        {
        //            command.Parameters.AddWithValue("@Id", quiz.QuizID);
        //            command.ExecuteNonQuery();

        //        }
        //    }
        //}


        public List<Quiz> GetAllQuizes()
        {
            List<Quiz> quizes = new List<Quiz>();

            using (SQLiteConnection connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();

                string getQuestionCommand = "SELECT * from quiz";

                using (SQLiteCommand questionCommand = new SQLiteCommand(getQuestionCommand, connection))
                {
                    QuestionRepository questionRepository = new QuestionRepository(_connectionString);
                    int quizId;
                    string quizName;
                    List<Question> questions;
                    SQLiteDataReader quizReader = questionCommand.ExecuteReader();
                    while (quizReader.Read())
                    {
                        quizId = (int)(long)quizReader["quiz_id"];
                        quizName = (string)quizReader["quiz_name"];
                        questions = questionRepository.GetQuestionByQuizId(quizId);
                        quizes.Add(new Quiz(questions, quizName, quizId));
                    }
                }
            }

            return quizes;

        }

    }
}
