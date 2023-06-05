using QuizMaker.Models;
using QuizMaker.Services;
using QuizMaker.Stores;
using QuizMaker.ViewModels;
using System;
using System.ComponentModel;

namespace QuizMaker.Commands
{
    public class EditQuizCommand : CommandBase
    {
        private readonly QuizesListViewModel _quizesListViewModel;
        private readonly QuizCollection _quizCollection;
        private readonly NavigationService _createQuestionsListViewModel;
        private readonly QuizStore _quizStore;

        public override void Execute(object? parameter)
        {
            int quizId = Int32.Parse(_quizesListViewModel.SelectedQuiz.QuizId);
            Quiz editedQuiz = _quizCollection.GetQuizById(quizId);

            _quizStore.CurrentQuiz = editedQuiz;
            _createQuestionsListViewModel.Navigate();
        }
        public override bool CanExecute(object? parameter)
        {
            return _quizesListViewModel.SelectedQuiz != null;
        }

        public EditQuizCommand(QuizesListViewModel quizesListViewModel, QuizCollection quizCollection, NavigationService createQuestionsListViewModel, QuizStore quizStore)
        {
            _quizesListViewModel = quizesListViewModel;
            _quizCollection = quizCollection;
            _createQuestionsListViewModel = createQuestionsListViewModel;
            _quizStore = quizStore;

            _quizesListViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }
        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(QuizesListViewModel.SelectedQuiz))
            {
                OnCanExecuteChanged();
            }
        }
    }
}
