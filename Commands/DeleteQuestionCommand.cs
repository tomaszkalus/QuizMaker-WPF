using QuizMaker.Models;
using QuizMaker.Stores;
using QuizMaker.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizMaker.Commands
{
    public class DeleteQuestionCommand : CommandBase
    {
        private readonly QuestionsListViewModel _questionsListViewModel;
        private readonly QuizStore _quizStore;
        private readonly Action _updateQuestions;


        public override void Execute(object? parameter)
        {
            int questionId = Int32.Parse(_questionsListViewModel.SelectedQuestion.QuestionId);
            Quiz currentQuiz = _quizStore.CurrentQuiz;
            currentQuiz.DeleteQuestion(questionId);

            _updateQuestions();
        }

        public override bool CanExecute(object? parameter)
        {
            return _questionsListViewModel.SelectedQuestion != null;
        }

        public DeleteQuestionCommand(QuestionsListViewModel questionsListViewModel, QuizStore quizStore, Action updateQuestions)
        {

            _questionsListViewModel = questionsListViewModel;
            _quizStore = quizStore;
            _updateQuestions = updateQuestions;

            _questionsListViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(QuestionsListViewModel.SelectedQuestion))
            {
                OnCanExecuteChanged();
            }
        }
    }
}
