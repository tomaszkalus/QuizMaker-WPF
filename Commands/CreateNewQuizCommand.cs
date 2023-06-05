using QuizMaker.Models;
using QuizMaker.Services;
using QuizMaker.Stores;
using QuizMaker.ViewModels;
using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows;
using System.ComponentModel;

namespace QuizMaker.Commands
{
    public class CreateNewQuizCommand : CommandBase
    {
        private readonly NavigationService _createQuestionsListViewModel;
        private readonly QuizStore _quizStore;
        private readonly QuizCollection _quizCollection;
        private readonly QuizNameEditViewModel _quizNameEditViewModel;

        public override void Execute(object? parameter)
        {
            string quizName = _quizNameEditViewModel.QuizName;
            if (_quizCollection.Conflicts(quizName)){

                MessageBox.Show("Nazwa quizu w bazie nie może się powtarzać", "Uwaga" , MessageBoxButton.OK, MessageBoxImage.Exclamation, MessageBoxResult.Yes);
                return;
            }

            Quiz newQuiz = new Quiz(new List<Question>(), quizName);
            _quizStore.CurrentQuiz = newQuiz;
            _quizCollection.AddQuiz(newQuiz);
            _createQuestionsListViewModel.Navigate();
        }

        public override bool CanExecute(object? parameter)
        {
            //return true;
            return !string.IsNullOrEmpty(_quizNameEditViewModel.QuizName);
        }
          
        public CreateNewQuizCommand(NavigationService createQuestionsListViewModel, QuizStore quizStore, QuizCollection quizCollection, QuizNameEditViewModel quizNameEditViewModel)
        {
            _createQuestionsListViewModel = createQuestionsListViewModel;
            _quizStore = quizStore;
            _quizCollection = quizCollection;
            _quizNameEditViewModel = quizNameEditViewModel;

            quizNameEditViewModel.PropertyChanged += OnViewModelPropertyChanged;


        }

        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(QuizNameEditViewModel.QuizName))
            {
                OnCanExecuteChanged();
            }
        }
    }
}
