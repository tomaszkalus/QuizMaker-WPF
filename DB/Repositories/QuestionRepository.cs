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

                    int lastId = (int)connection.LastInsertRowId;
                    Trace.WriteLine(lastId.ToString());

                    string insertAnswerQuery = @"INSERT INTO answer(question_id, answer_text, answer_field, answer_is_correct)
                                            VALUES (@question_id, @answer_text, @answer_field, @answer_is_correct)";

                    foreach (Answer answer in question.Answers)
                    {
                        using (SQLiteCommand answerCommand = new SQLiteCommand(insertAnswerQuery, connection))
                        {
                            answerCommand.Parameters.AddWithValue("@question_id", lastId);
                            answerCommand.Parameters.AddWithValue("@answer_text", answer.Text);
                            answerCommand.Parameters.AddWithValue("@answer_field", answer.Field);
                            answerCommand.Parameters.AddWithValue("@answer_is_correct", answer.IsCorrect ? 1 : 0);
                            answerCommand.ExecuteNonQuery();
                        }
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

            Question question;
            string questionText;
            int questionOrder;

            List<Answer> answers = new List<Answer>();
            int answerId;
            string answerText;
            int answerField;
            bool answerIsCorrect;

            using (SQLiteConnection connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
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


                    string getAnswersCommand = @"SELECT 
                                                answer.answer_id,
                                                answer.answer_text,
                                                answer.answer_field,
                                                answer.answer_is_correct
                                                FROM answer
                                                LEFT JOIN question
                                                ON question.question_ID = answer.question_ID
                                                WHERE question.question_ID = @question_id";

                    using (SQLiteCommand answersCommand = new SQLiteCommand(getAnswersCommand, connection))
                    {
                        answersCommand.Parameters.AddWithValue("@question_id", questionId);
                        SQLiteDataReader answersReader = answersCommand.ExecuteReader();

                        while (answersReader.Read())
                        {
                            answerId = (int)(long)answersReader["answer_id"];
                            answerText = (string)answersReader["answer_text"];
                            answerField = (int)(long)answersReader["answer_field"];
                            answerIsCorrect = Convert.ToBoolean((long)answersReader["answer_is_correct"]);

                            Answer answer = new Answer(answerText, answerIsCorrect, answerField, answerId);
                            answers.Add(answer);
                        }
                    }
                    transaction.Commit();
                }
            }
            question = new Question(questionText, answers, questionOrder, questionId);
            return question;


        }

        public void UpdateQuestion(Question question)
        {
            throw new NotImplementedException();
        }
    }
}
