using QuizMaker.DB;
using QuizMaker.DB.Repositories;
using QuizMaker.Models;
using QuizMaker.Stores;
using QuizMaker.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;

namespace QuizMaker
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly NavigationStore _navigationStore;

        public App()
        {
            _navigationStore = new NavigationStore();
            
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            #region testing
            //string conn_string = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            //List<Answer> answer_list = new List<Answer>();
            //Answer answer1 = new Answer("test odp01", true, 1);
            //Answer answer2 = new Answer("test odp02", false, 2);
            //Answer answer3 = new Answer("test odp03", false, 3);
            //Answer answer4 = new Answer("test odp04", false, 4);
            //answer_list.Add(answer1); answer_list.Add(answer2); answer_list.Add(answer3); answer_list.Add(answer4);

            //Question question = new Question("test pytanie 01", answer_list, 3);
            //QuestionRepository questionRepository = new QuestionRepository(conn_string);

            //QuizRepository quizRepo = new QuizRepository(conn_string);
            //List<Quiz> quizes = quizRepo.GetAllQuizes();
            #endregion

            _navigationStore.CurrentViewModel = new StartPageViewModel(_navigationStore, CreateQuizesListViewModel);

            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_navigationStore)
            };
            MainWindow.Show();

            base.OnStartup(e);


        }

        private QuizesListViewModel CreateQuizesListViewModel()
        {
            return new QuizesListViewModel(_navigationStore);
        }

        private QuestionsListViewModel CreateQuestionsListViewModel()
        {
            return new QuestionsListViewModel();
        }
        private AnswersEditViewModel CreateAnswersEditViewModel()
        {
            return new AnswersEditViewModel();
        }


    }
}
