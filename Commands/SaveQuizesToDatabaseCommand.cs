using QuizMaker.DB;
using QuizMaker.DB.Repositories;
using QuizMaker.Models;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizMaker.Commands
{
    public class SaveQuizesToDatabaseCommand : CommandBase
    {
        private string _databasePath;
        private readonly QuizCollection _quizCollection;

        public override void Execute(object? parameter)
        {
            GetDatabasePath();
            if (_databasePath == null) { return; }

            DataAccess dataAccess = new DataAccess(_databasePath);
            QuizRepository quizRepository = new QuizRepository();
            SQLiteConnection connection = dataAccess.Connection;
            connection.Open();

            quizRepository.SaveQuizesToDatabase(connection, _quizCollection);
            connection.Close();


        }

        public SaveQuizesToDatabaseCommand(QuizCollection quizCollection)
        {
            _databasePath = null;
            _quizCollection = quizCollection;
        }

        private void GetDatabasePath()
        {
            var dialog = new Microsoft.Win32.SaveFileDialog();
            dialog.FileName = "QuizDatabase";
            dialog.DefaultExt = ".db";
            dialog.Filter = "SQLite3 Database |*.db";

            bool? result = dialog.ShowDialog();

            if (result == false)
            {
                return;
            }

            _databasePath = dialog.FileName;
        }

        private void SaveQuizes()
        {



        }
    }
}
