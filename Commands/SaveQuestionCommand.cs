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
    internal class SaveQuestionCommand : CommandBase
    {
        private AnswersEditViewModel _answersEditViewModel;
        private NavigationService _createQuestionsListViewModel;
        private QuizStore _quizStore;
        private QuestionStore _questionStore;

        public override void Execute(object? parameter)
        {
            Answer answer1 = new Answer(_answersEditViewModel.Answer1Text, _answersEditViewModel.Answer1Correct, 1);
            Answer answer2 = new Answer(_answersEditViewModel.Answer2Text, _answersEditViewModel.Answer2Correct, 2);
            Answer answer3 = new Answer(_answersEditViewModel.Answer3Text, _answersEditViewModel.Answer3Correct, 3);
            Answer answer4 = new Answer(_answersEditViewModel.Answer4Text, _answersEditViewModel.Answer4Correct, 4);

            List<Answer> answers = new List<Answer> { answer1, answer2, answer3, answer4 };

            Question newQuestion = new Question(_answersEditViewModel.QuestionName, answers, _answersEditViewModel.QuestionOrder);
            Quiz currentQuiz = _quizStore.CurrentQuiz;
            if (_questionStore.CurrentQuestion != null)
            {
                int questionId = _questionStore.CurrentQuestion.QuestionId;
                currentQuiz.ModifyQuestion(newQuestion, questionId);

            }

            else
            {
                currentQuiz.AddQuestion(newQuestion);
            }

            _questionStore.CurrentQuestion = null;
            _createQuestionsListViewModel.Navigate();
        }

        public override bool CanExecute(object? parameter)
        {
            return !string.IsNullOrEmpty(_answersEditViewModel.QuestionName)
                && !string.IsNullOrEmpty(_answersEditViewModel.Answer1Text)
                && !string.IsNullOrEmpty(_answersEditViewModel.Answer2Text)
                && !string.IsNullOrEmpty(_answersEditViewModel.Answer3Text)
                && !string.IsNullOrEmpty(_answersEditViewModel.Answer4Text)
                && (_answersEditViewModel.Answer1Correct 
                || _answersEditViewModel.Answer2Correct 
                || _answersEditViewModel.Answer3Correct  
                || _answersEditViewModel.Answer4Correct);

        }
        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(AnswersEditViewModel.QuestionName)
                || e.PropertyName == nameof(AnswersEditViewModel.QuestionOrder)
                || e.PropertyName == nameof(AnswersEditViewModel.Answer1Text)
                || e.PropertyName == nameof(AnswersEditViewModel.Answer1Correct)
                || e.PropertyName == nameof(AnswersEditViewModel.Answer2Text)
                || e.PropertyName == nameof(AnswersEditViewModel.Answer2Correct)
                || e.PropertyName == nameof(AnswersEditViewModel.Answer3Text)
                || e.PropertyName == nameof(AnswersEditViewModel.Answer3Correct)
                || e.PropertyName == nameof(AnswersEditViewModel.Answer4Text)
                || e.PropertyName == nameof(AnswersEditViewModel.Answer4Correct))
            {
                OnCanExecuteChanged();
            }
        }

        public SaveQuestionCommand(AnswersEditViewModel answersEditViewModel, QuizStore quizStore, QuestionStore questionStore, NavigationService createQuestionsListViewModel)
        {
            _answersEditViewModel = answersEditViewModel;
            _createQuestionsListViewModel = createQuestionsListViewModel;
            _quizStore = quizStore;
            _questionStore = questionStore;

            _answersEditViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }
    }
}
