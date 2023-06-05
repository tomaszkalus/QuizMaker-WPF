using QuizMaker.Models;
using QuizMaker.Services;
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
    public class EditQuestionCommand : CommandBase
    {
        private readonly QuestionsListViewModel _questionsListViewModel;
        private readonly QuizStore _quizStore;
        private readonly QuestionStore _questionStore;
        private NavigationService _createAnswersEditViewModel;

        public override void Execute(object? parameter)
        {
            int questionId = Int32.Parse(_questionsListViewModel.SelectedQuestion.QuestionId);
            Quiz editedQuestionQuiz = _quizStore.CurrentQuiz;
            Question editedQuestion = editedQuestionQuiz.GetQuestionById(questionId);
            _questionStore.CurrentQuestion = editedQuestion;

            _createAnswersEditViewModel.Navigate();
        }

        public override bool CanExecute(object? parameter)
        {
            return _questionsListViewModel.SelectedQuestion != null;
        }

        public EditQuestionCommand(QuestionsListViewModel questionsListViewModel, QuizStore quizStore, QuestionStore questionStore, NavigationService createAnswersEditViewModel)
        {
            _questionsListViewModel = questionsListViewModel;
            _quizStore = quizStore;
            _questionStore = questionStore;
            _createAnswersEditViewModel = createAnswersEditViewModel;

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
