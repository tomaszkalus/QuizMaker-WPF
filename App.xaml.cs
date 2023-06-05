using QuizMaker.Models;
using QuizMaker.Services;
using QuizMaker.Stores;
using QuizMaker.ViewModels;
using System.Collections.Generic;
using System.Windows;

namespace QuizMaker
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly NavigationStore _navigationStore;
        private readonly QuizCollection _quizCollection;
        private readonly QuestionStore _questionStore;
        private readonly QuizStore _quizStore;
        private string _dbPath;

        public App()
        {
            _navigationStore = new NavigationStore();
            _quizStore = new QuizStore();
            _quizCollection = new QuizCollection(new List<Quiz>());
            _questionStore = new QuestionStore();

            _dbPath = null;
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            #region testing

            #endregion

            _navigationStore.CurrentViewModel = CreateStartPageViewModel();

            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_navigationStore)
            };
            MainWindow.Show();

            base.OnStartup(e);


        }

        private QuizesListViewModel CreateQuizesListViewModel()
        {
            return new QuizesListViewModel(_quizCollection, _quizStore, _dbPath, new NavigationService(_navigationStore, CreateQuizNameEditViewModel), new NavigationService(_navigationStore, CreateQuestionsListViewModel));
        }

        private QuestionsListViewModel CreateQuestionsListViewModel()
        {
            return new QuestionsListViewModel(_quizStore, _questionStore, new NavigationService(_navigationStore, CreateAnswersEditViewModel), new NavigationService(_navigationStore, CreateQuizesListViewModel));
        }
        private AnswersEditViewModel CreateAnswersEditViewModel()
        {
            return new AnswersEditViewModel(_quizStore, _questionStore, new NavigationService(_navigationStore, CreateQuestionsListViewModel));
        }
        private StartPageViewModel CreateStartPageViewModel()
        {
            return new StartPageViewModel(_quizCollection, _dbPath, new NavigationService(_navigationStore, CreateQuizesListViewModel));
        }
        private QuizNameEditViewModel CreateQuizNameEditViewModel()
        {
            return new QuizNameEditViewModel(_quizStore, _quizCollection, new NavigationService(_navigationStore, CreateQuizesListViewModel), new NavigationService(_navigationStore, CreateQuestionsListViewModel));
        }


    }
}
