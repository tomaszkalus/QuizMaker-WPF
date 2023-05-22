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
        private readonly SQLiteConnection _connection;

        public AnswerRepository(SQLiteConnection connection)
        {
            _connection = connection;
        }


        public void AddAnswer(Answer answer, int questionId, SQLiteTransaction transaction)
        {
            string query = @"INSERT INTO answer(question_id,answer_text,answer_field,answer_is_correct)
                            VALUES(@questionId, @text, @field, @is_correct)";

            using (SQLiteCommand command = new SQLiteCommand(query, _connection, transaction))
            {
                command.Parameters.AddWithValue("@questionId", questionId);
                command.Parameters.AddWithValue("@text", answer.Text);
                command.Parameters.AddWithValue("@field", answer.Field);
                command.Parameters.AddWithValue("@is_correct", answer.IsCorrect ? 1 : 0);

                command.ExecuteNonQuery();
            }
        }

        public List<Answer> GetAnswersByQuestionID(int questionID)
        {

            string query = @"
            SELECT 
            answer.answer_id,
            answer.answer_text,
            answer.answer_field,
            answer.answer_is_correct
            FROM answer
            LEFT JOIN question
            ON question.question_id = answer.question_id
            WHERE question.question_id = @question_id";

            using (SQLiteCommand command = new SQLiteCommand(query, _connection))
            {
                command.Parameters.AddWithValue("@question_id", questionID);

                List<Answer> answers = new List<Answer>();

                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = (int)(long)reader["answer_id"];
                        string text = (string)reader["answer_text"];
                        int field = (int)(long)reader["answer_field"];
                        bool isCorrect = Convert.ToBoolean((long)reader["answer_is_correct"]);

                        Answer answer = new Answer(text, isCorrect, field, id);
                        answers.Add(answer);

                    }
                }
                return answers;
            }
            
        }

        public void UpdateAnswer(Answer answer, SQLiteTransaction transaction)
        {
            string query = @"
                            UPDATE Answer
                            SET
                            Answer_Text = @text,
                            Answer_Field = @field,
                            Answer_IsCorrect = @is_correct
                            WHERE
                            Answer_ID = @answer_id";

            using (SQLiteCommand command = new SQLiteCommand(query, _connection, transaction))
            {
                command.Parameters.AddWithValue("@answer_id", answer.AnswerID.ToString());
                command.Parameters.AddWithValue("@text", answer.Text);
                command.Parameters.AddWithValue("@field", answer.Field);
                command.Parameters.AddWithValue("@is_correct", answer.IsCorrect ? 1 : 0);
                command.ExecuteNonQuery();

            }
            
        }


    }
}
