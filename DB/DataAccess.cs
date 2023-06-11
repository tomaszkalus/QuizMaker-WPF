using System.Configuration;
using System.Data;
using System.Data.SQLite;

namespace QuizMaker.DB
{
    public class DataAccess
    {
        private SQLiteConnection _connection;
        private string _databasePath;

        public SQLiteConnection Connection => _connection;

        public DataAccess(string databasePath)
        {
            _connection = new SQLiteConnection($"Data Source={databasePath};Version=3");
            _databasePath = databasePath;
            CreateDatabase();
        }

        private void CreateDatabase()
        {
            SQLiteConnection.CreateFile(_databasePath);

            _connection.Open();

            SQLiteCommand createQuizTableCommand = new SQLiteCommand(Resources.CreateDatabaseSql.CreateQuizTable, _connection);
            SQLiteCommand createQuestionTableCommand = new SQLiteCommand(Resources.CreateDatabaseSql.CreateQuestionsTable, _connection);
            SQLiteCommand createAnswerTableCommand = new SQLiteCommand(Resources.CreateDatabaseSql.CreateAnswersTable, _connection);

            createQuizTableCommand.ExecuteNonQuery();
            createQuestionTableCommand.ExecuteNonQuery();
            createAnswerTableCommand.ExecuteNonQuery();

            _connection.Close();
        }





    }
}
