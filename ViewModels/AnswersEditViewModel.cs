using QuizMaker.Commands;
using QuizMaker.Models;
using QuizMaker.Services;
using QuizMaker.Stores;
using System;
using System.Windows.Input;

namespace QuizMaker.ViewModels
{
    public class AnswersEditViewModel : ViewModelBase
    {
        #region parameters_init 
        // Question Name
        private string _questionName;
        public string QuestionName
        {
            get
            {
                return _questionName;
            }
            set
            {
                _questionName = value;
                OnPropertyChanged(nameof(QuestionName));
            }
        }

        // Question Order
        private int _questionOrder;
        public int QuestionOrder
        {
            get
            {
                return _questionOrder;
            }
            set
            {
                _questionOrder = value;
                OnPropertyChanged(nameof(QuestionOrder));
            }
        }

        // Answer 1
        private string _answer1Text;
        public string Answer1Text
        {
            get
            {
                return _answer1Text;
            }
            set
            {
                _answer1Text = value;
                OnPropertyChanged(nameof(Answer1Text));
            }
        }

        private bool _answer1Correct;
        public bool Answer1Correct
        {
            get
            {
                return _answer1Correct;
            }
            set
            {
                _answer1Correct = value;
                OnPropertyChanged(nameof(Answer1Correct));
            }
        }

        // Answer 2
        private string _answer2Text;
        public string Answer2Text
        {
            get
            {
                return _answer2Text;
            }
            set
            {
                _answer2Text = value;
                OnPropertyChanged(nameof(Answer2Text));
            }
        }

        private bool _answer2Correct;
        public bool Answer2Correct
        {
            get
            {
                return _answer2Correct;
            }
            set
            {
                _answer2Correct = value;
                OnPropertyChanged(nameof(Answer2Correct));
            }
        }

        // Answer 3
        private string _answer3Text;
        public string Answer3Text
        {
            get
            {
                return _answer3Text;
            }
            set
            {
                _answer3Text = value;
                OnPropertyChanged(nameof(Answer3Text));
            }
        }

        private bool _answer3Correct;
        public bool Answer3Correct
        {
            get
            {
                return _answer3Correct;
            }
            set
            {
                _answer3Correct = value;
                OnPropertyChanged(nameof(Answer3Correct));
            }
        }

        // Answer 4
        private string _answer4Text;
        public string Answer4Text
        {
            get
            {
                return _answer4Text;
            }
            set
            {
                _answer4Text = value;
                OnPropertyChanged(nameof(Answer4Text));
            }
        }

        private bool _answer4Correct;
        public bool Answer4Correct
        {
            get
            {
                return _answer4Correct;
            }
            set
            {
                _answer4Correct = value;
                OnPropertyChanged(nameof(Answer4Correct));
            }
        }
        #endregion


        // Commands
        public ICommand CancelAnswersCommand { get; }
        public ICommand SaveAnswersCommand { get; }
        public ICommand ValidateNumericInputCommand { get; }
        private readonly QuestionStore _questionStore;


        public AnswersEditViewModel(QuizStore quizStore, QuestionStore questionStore, NavigationService createQuestionsListViewModel)
        {
            _questionStore = questionStore;
            QuestionOrder = quizStore.CurrentQuiz.NumberOfQuestions + 1;
            UpdateData();

            CancelAnswersCommand = new CancelEditQuestionCommand(createQuestionsListViewModel, questionStore);
            SaveAnswersCommand = new SaveQuestionCommand(this, quizStore, questionStore, createQuestionsListViewModel);
        }

        private void UpdateData()
        {
            // Load the edited question if specified
            if (_questionStore.CurrentQuestion != null)
            {
                Question editedQuestion = _questionStore.CurrentQuestion;

                QuestionName = editedQuestion.Text;
                QuestionOrder = editedQuestion.Order;


                if (editedQuestion.Answers.Count > 0)
                {
                    Answer answer1 = editedQuestion.Answers[0] ?? new Answer("", false, 1);
                    Answer1Text = answer1.Text;
                    Answer1Correct = answer1.IsCorrect;
                }

                if (editedQuestion.Answers.Count > 1)
                {
                    Answer answer2 = editedQuestion.Answers[1] ?? new Answer("", false, 2);
                    Answer2Text = answer2.Text;
                    Answer2Correct = answer2.IsCorrect;
                }

                if (editedQuestion.Answers.Count > 2)
                {
                    Answer answer3 = editedQuestion.Answers[2] ?? new Answer("", false, 3);
                    Answer3Text = answer3.Text;
                    Answer3Correct = answer3.IsCorrect;
                }

                if (editedQuestion.Answers.Count > 3)
                {
                    Answer answer4 = editedQuestion.Answers[3] ?? new Answer("", false, 4);
                    Answer4Text = answer4.Text;
                    Answer4Correct = answer4.IsCorrect;
                }
            }
        }
    }
}
