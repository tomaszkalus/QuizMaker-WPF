using QuizMaker.DB.Repositories;
using QuizMaker.Models;
using QuizMaker.Services;
using System.Collections.Generic;
using System.Data.SQLite;

namespace QuizMaker.Commands
{
    public class OpenDatabaseCommand : CommandBase
    {
        private NavigationService _createQuestionsListViewModel;
        private QuizCollection _quizCollection;
        private string _databasePath;

        public OpenDatabaseCommand(QuizCollection quizCollection, string databasePath, NavigationService createQuestionsListViewModel)
        {
            _createQuestionsListViewModel = createQuestionsListViewModel;
            _quizCollection = quizCollection;
            _databasePath = databasePath;



        }
        public override void Execute(object? parameter)
        {
            var dialog = new Microsoft.Win32.OpenFileDialog();
            dialog.FileName = "QuizDatabase";
            dialog.DefaultExt = ".db";
            dialog.Filter = "SQLite3 Database |*.db";

            bool? result = dialog.ShowDialog();

            if (result == false)
            {
                return;
            }

            _databasePath = dialog.FileName;
            loadQuizes(_databasePath);
            _createQuestionsListViewModel.Navigate();
        }

        private void loadQuizes(string filename)
        {
            SQLiteConnection connection = new SQLiteConnection($"Data Source={filename};Version=3");
            connection.Open();
            QuizRepository quizRepository = new QuizRepository();
            List<Quiz> quizes = quizRepository.GetAllQuizes(connection);
            foreach (var quiz in quizes)
            {
                _quizCollection.AddQuiz(quiz);
            }
        }
    }
}
