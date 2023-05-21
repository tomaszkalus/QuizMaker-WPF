using QuizMaker.Models;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizMaker.DB.Repositories
{
    public class AnswerRepository : IAnswersRepository
    {
        private readonly string _connectionString;

        public AnswerRepository(string connectionString) 
        {
            _connectionString = connectionString;
        }

        public void AddAnswer(Answer answer, int questionId)
        {
            using (SQLiteConnection connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                string query = @"INSERT INTO Answer(Question_ID,Answer_Text,Answer_Field,Answer_IsCorrect)
                                VALUES(@questionId, @text, @field, @is_correct)";

                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@questionId", questionId);
                    command.Parameters.AddWithValue("@text", answer.Text);
                    command.Parameters.AddWithValue("@field", answer.Field);
                    command.Parameters.AddWithValue("@is_correct", answer.IsCorrect ? 1 : 0);

                    try
                    {
                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
            }
        }

        public void DeleteAnswer(Answer answer)
        {
            using (SQLiteConnection connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                string query = "DELETE FROM Answer WHERE Answer_ID = @Id";

                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", answer.AnswerID.ToString());
                    try
                    {
                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
            }
        }

        public List<Answer> GetAnswersByQuestionID(int questionID)
        {
            using (SQLiteConnection connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                string query = @"
                SELECT 
                Answer.Answer_ID,
                Answer.Answer_Text,
                Answer.Answer_Field,
                Answer.Answer_IsCorrect
                FROM Answer
                LEFT JOIN Question
                ON Question.Question_ID = Answer.Question_ID
                WHERE Question.Question_ID = @question_id";

                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@question_id", questionID);

                    List<Answer> answers = new List<Answer>();

                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = (int)(long)reader["Answer_ID"];
                            string text = (string)reader["Answer_Text"];
                            int field = (int)(long)reader["Answer_Field"];
                            bool isCorrect = Convert.ToBoolean((long)reader["Answer_IsCorrect"]);

                            Answer answer = new Answer(text, isCorrect, field, id);
                            answers.Add(answer);

                        }
                    }
                    return answers;
                }
            }
        }

        public void UpdateAnswer(Answer answer)
        {
            using (SQLiteConnection connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                string query = @"
                                UPDATE Answer
                                SET
                                Answer_Text = @text,
                                Answer_Field = @field,
                                Answer_IsCorrect = @is_correct
                                WHERE
                                Answer_ID = @answer_id";

                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@answer_id", answer.AnswerID.ToString());
                    command.Parameters.AddWithValue("@text", answer.Text);
                    command.Parameters.AddWithValue("@field", answer.Field);
                    command.Parameters.AddWithValue("@is_correct", answer.IsCorrect ? 1 : 0);
                    try
                    {
                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
            }
        }
    }
}
