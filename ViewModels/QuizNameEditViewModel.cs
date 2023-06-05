using QuizMaker.Commands;
using QuizMaker.Models;
using QuizMaker.Services;
using QuizMaker.Stores;
using System.Windows.Input;

namespace QuizMaker.ViewModels
{
    public class QuizNameEditViewModel : ViewModelBase
    {
        public ICommand SaveQuizNameCommand { get; }
        public ICommand CancelCreateQuizCommand { get; }

        private string _quizName;
        public string QuizName
        {
            get { return _quizName; }
            set { 
                _quizName = value; 
                OnPropertyChanged(nameof(QuizName));
            }
        }

        public QuizNameEditViewModel(QuizStore quizStore, QuizCollection quizCollection, NavigationService createQuizesListViewModel, NavigationService createQuestionsListViewModel)
        {
            SaveQuizNameCommand = new CreateNewQuizCommand(createQuestionsListViewModel, quizStore, quizCollection, this);
            CancelCreateQuizCommand = new NavigateCommand(createQuizesListViewModel);
        }

    }
}
