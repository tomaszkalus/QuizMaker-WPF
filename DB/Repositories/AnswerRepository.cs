using QuizMaker.Models;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizMaker.DB.Repositories
{
    public class AnswerRepository
    {
        public void AddAnswer(Answer answer, long questionId, SQLiteConnection connection)
        {
            string query = @"INSERT INTO Answer(Question_ID,Answer_Text,Answer_Field,Answer_IsCorrect)
                            VALUES(@questionId, @text, @field, @is_correct)";

            using (SQLiteCommand command = new SQLiteCommand(query, connection))
            {
                command.Parameters.AddWithValue("@questionId", questionId);
                command.Parameters.AddWithValue("@text", answer.Text);
                command.Parameters.AddWithValue("@field", answer.Field);
                command.Parameters.AddWithValue("@is_correct", answer.IsCorrect ? 1 : 0);

                command.ExecuteNonQuery();
            }
        }

        public List<Answer> GetAnswersByQuestionID(int questionID, SQLiteConnection connection)
        {

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

                        Answer answer = new Answer(text, isCorrect, field);
                        answers.Add(answer);

                    }
                }
                return answers;
            }
            
        }


    }
}
