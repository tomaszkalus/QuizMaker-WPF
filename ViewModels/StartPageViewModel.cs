using QuizMaker.Commands;
using QuizMaker.Models;
using QuizMaker.Services;
using System.Windows.Input;

namespace QuizMaker.ViewModels
{
    public class StartPageViewModel : ViewModelBase
    {
        public ICommand CreateDatabaseCommand { get; }
        public ICommand OpenDatabaseCommand { get; }

        public StartPageViewModel(QuizCollection quizCollection, string databasePath, NavigationService createQuizesListViewModel)
        {
            CreateDatabaseCommand = new NavigateCommand(createQuizesListViewModel);
            OpenDatabaseCommand = new OpenDatabaseCommand(quizCollection, databasePath, createQuizesListViewModel);
        }
    }
}
