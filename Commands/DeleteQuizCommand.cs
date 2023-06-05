using QuizMaker.Models;
using QuizMaker.Services;
using QuizMaker.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizMaker.Commands
{
    public class DeleteQuizCommand : CommandBase
    {
        private readonly QuizesListViewModel _quizesListViewModel;
        private readonly QuizCollection _quizCollection;
        private readonly NavigationService _createQuizNameEditViewModel;
        private readonly Action _updateQuizes;

        public override void Execute(object? parameter)
        {
            int quizId = Int32.Parse(_quizesListViewModel.SelectedQuiz.QuizId);
            _quizCollection.DeleteQuiz(quizId);
            _updateQuizes();
        }
        public override bool CanExecute(object? parameter)
        {
            return _quizesListViewModel.SelectedQuiz != null;
        }

        public DeleteQuizCommand(QuizesListViewModel quizesListViewModel, QuizCollection quizCollection, Action updateQuizes)
        {
            _quizesListViewModel = quizesListViewModel;
            _quizCollection = quizCollection;
            _updateQuizes = updateQuizes;

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
