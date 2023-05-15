using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace QuizMaker.ViewModels
{
    public class AnswersEditViewModel : ViewModelBase
    {

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

        // Commands
        public ICommand CancelAnswersCommand { get; }

        public ICommand SaveAnswersCommand { get; }

        public AnswersEditViewModel()
        {

        }
    }
}
