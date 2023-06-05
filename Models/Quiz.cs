using System.Collections.Generic;

namespace QuizMaker.Models
{
    public class Quiz
    {
        private readonly List<Question> _questions;

        private static int nrOfInstances = 0;
        private readonly int _quizId;
        public int QuizId => _quizId;
        public string QuizName { get; }
        public int NumberOfQuestions => _questions.Count;

        public Quiz(List<Question> questions, string quizName)
        {
            // Assigning a new unique ID for each quiz
            _quizId = Quiz.nrOfInstances;
            Quiz.nrOfInstances++;

            _questions = questions;
            QuizName = quizName;
        }

        public void AddQuestion(Question question)
        {
            _questions.Add(question);
        }

        public IEnumerable<Question> GetAllQuestions()
        {
            return _questions;
        }

        public Question GetQuestionById(int id)
        {
            return _questions.Find(x => x.QuestionId == id);

        }

        public void DeleteQuestion(int id)
        {
            Question questionToDelete = _questions.Find(x => x.QuestionId == id);
            _questions.Remove(questionToDelete);
        }

        public void ModifyQuestion(Question question, int questionId)
        {
            DeleteQuestion(questionId);
            AddQuestion(question);

        }

    }
}
