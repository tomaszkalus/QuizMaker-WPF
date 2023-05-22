using QuizMaker.Models;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizMaker.DB.Repositories
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly string _connectionString;

        public QuestionRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void AddQuestion(Question question, int quizId)
        {
            using (SQLiteConnection connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    string insertQuestionQuery = @"INSERT INTO question(quiz_id, question_name, question_order)
                                VALUES (@quiz_id, @question_name, @question_order)";

                    using (SQLiteCommand questionCommand = new SQLiteCommand(insertQuestionQuery, connection))
                    {
                        questionCommand.Parameters.AddWithValue("@quiz_id", quizId);
                        questionCommand.Parameters.AddWithValue("@question_name", question.Text);
                        questionCommand.Parameters.AddWithValue("@question_order", question.Order);
                        questionCommand.ExecuteNonQuery();
                    }

                    int questionId = (int)connection.LastInsertRowId;

                    AnswerRepository answerRepository = new AnswerRepository(connection);

                    foreach (Answer answer in question.Answers)
                    {
                        answerRepository.AddAnswer(answer, questionId, transaction);
                    }

                    transaction.Commit();
                }
            }
        }

        public void DeleteQuestion(Question question)
        {
            using (SQLiteConnection connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();

                using (SQLiteCommand pragmaCommand = new SQLiteCommand("PRAGMA foreign_keys=on", connection))
                {
                    pragmaCommand.ExecuteNonQuery();
                }

                string questionDeleteQuery = "DELETE FROM question WHERE question_id = @Id";
                using (SQLiteCommand command = new SQLiteCommand(questionDeleteQuery, connection))
                {
                    command.Parameters.AddWithValue("@Id", question.QuestionID);
                    command.ExecuteNonQuery();

                }
            }
        }

        public Question GetQuestionByID(int questionId)
        {
            string questionText;
            int questionOrder;
            List<Answer> answers = new List<Answer>();

            using (SQLiteConnection connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();

                string getQuestionCommand = @"SELECT *
                                            FROM question
                                            WHERE question_id = @question_id";

                using (SQLiteCommand questionCommand = new SQLiteCommand(getQuestionCommand, connection))
                {
                    questionCommand.Parameters.AddWithValue("@question_id", questionId);
                    SQLiteDataReader questionReader = questionCommand.ExecuteReader();
                    questionReader.Read();

                    questionText = (string)questionReader["question_name"];
                    questionOrder = (int)(long)questionReader["question_order"];
                }

                AnswerRepository answerRepository = new AnswerRepository(connection);
                answers = answerRepository.GetAnswersByQuestionID(questionId);
            }

            return new Question(questionText, answers, questionOrder, questionId);
        }

        public List<Question> GetQuestionByQuizId(int quizId)
        {
            List<Question> questions = new List<Question>();

            using (SQLiteConnection connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                string getQuestionByQuizIdCommand = @"SELECT 
                                                    question.question_ID,
                                                    question.question_Name,
                                                    question.question_Order
                                                    FROM question
                                                    JOIN quiz
                                                    ON quiz.quiz_ID = question.quiz_ID
                                                    WHERE quiz.quiz_ID = @quiz_id";


                using (SQLiteCommand questionCommand = new SQLiteCommand(getQuestionByQuizIdCommand, connection))
                {
                    questionCommand.Parameters.AddWithValue("@quiz_id", quizId);
                    SQLiteDataReader questionReader = questionCommand.ExecuteReader();
                    string questionText;
                    int questionOrder;
                    int questionId;
                    List<Answer> answers = new List<Answer>();
                    AnswerRepository answerRepository = new AnswerRepository(connection);
                    while (questionReader.Read())
                    {
                        questionId = (int)(long)questionReader["question_id"];
                        questionText = (string)questionReader["question_name"];
                        questionOrder = (int)(long)questionReader["question_order"];
                        
                        answers = answerRepository.GetAnswersByQuestionID(questionId);
                        questions.Add(new Question(questionText, answers, questionOrder, questionId));
                    }
                }
            }
            return questions;
        }


        public void UpdateQuestion(Question question)
        {
            throw new NotImplementedException();
        }
    }
}
