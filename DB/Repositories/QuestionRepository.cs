using QuizMaker.Models;
using System.Collections.Generic;
using System.Data.SQLite;

namespace QuizMaker.DB.Repositories
{
    public class QuestionRepository
    {
        public void AddQuestion(SQLiteConnection connection, Question question, long quizId)
        {
            string insertQuestionQuery = @"INSERT INTO Question(Quiz_ID, Question_Name, Question_Order)
                        VALUES (@quiz_id, @question_name, @question_order)";

            using (SQLiteCommand questionCommand = new SQLiteCommand(insertQuestionQuery, connection))
            {
                questionCommand.Parameters.AddWithValue("@quiz_id", quizId);
                questionCommand.Parameters.AddWithValue("@question_name", question.Text);
                questionCommand.Parameters.AddWithValue("@question_order", question.Order);
                questionCommand.ExecuteNonQuery();
            }

            long questionId = connection.LastInsertRowId;

            AnswerRepository answerRepository = new AnswerRepository();

            foreach (Answer answer in question.Answers)
            {
                answerRepository.AddAnswer(answer, questionId, connection);
            }
        }

        public Question GetQuestionByID(SQLiteConnection connection, int questionId)
        {
            string questionText;
            int questionOrder;
            List<Answer> answers = new List<Answer>();
            connection.Open();

            string getQuestionCommand = @"SELECT *
                                        FROM Question
                                        WHERE Question_ID = @question_id";

            using (SQLiteCommand questionCommand = new SQLiteCommand(getQuestionCommand, connection))
            {
                questionCommand.Parameters.AddWithValue("@question_id", questionId);
                SQLiteDataReader questionReader = questionCommand.ExecuteReader();
                questionReader.Read();

                questionText = (string)questionReader["question_name"];
                questionOrder = (int)(long)questionReader["question_order"];
            }

            AnswerRepository answerRepository = new AnswerRepository();
            answers = answerRepository.GetAnswersByQuestionID(questionId, connection);


            return new Question(questionText, answers, questionOrder);
        }

        public List<Question> GetQuestionByQuizId(int quizId, SQLiteConnection connection)
        {
            List<Question> questions = new List<Question>();

            string getQuestionByQuizIdCommand = @"SELECT 
                                                Question.Question_ID,
                                                Question.Question_Name,
                                                Question.Question_Order
                                                FROM Question
                                                JOIN Quiz
                                                ON Quiz.Quiz_ID = Question.Quiz_ID
                                                WHERE Quiz.Quiz_ID = @quiz_id";


            using (SQLiteCommand questionCommand = new SQLiteCommand(getQuestionByQuizIdCommand, connection))
            {
                questionCommand.Parameters.AddWithValue("@quiz_id", quizId);
                SQLiteDataReader questionReader = questionCommand.ExecuteReader();
                string questionText;
                int questionOrder;
                int questionId;
                List<Answer> answers = new List<Answer>();
                AnswerRepository answerRepository = new AnswerRepository();
                while (questionReader.Read())
                {
                    questionId = (int)(long)questionReader["Question_ID"];
                    questionText = (string)questionReader["Question_Name"];
                    questionOrder = (int)(long)questionReader["Question_Order"];

                    answers = answerRepository.GetAnswersByQuestionID(questionId, connection);
                    questions.Add(new Question(questionText, answers, questionOrder));
                }
            }

            return questions;
        }

    }
}
