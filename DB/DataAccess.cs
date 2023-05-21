using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SQLite;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace QuizMaker.DB
{
    public class DataAccess
    {
        private SQLiteConnection _connString = new SQLiteConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

        public DataTable FetchData(string query)
        {
            SQLiteCommand command;
            var dataset = new DataTable();
            using (var conn = new SQLiteConnection(_connString))
            {
                conn.Open();
                command = new SQLiteCommand(query, conn);
                var adapter = new SQLiteDataAdapter(command);
                adapter.Fill(dataset);
                conn.Close();
                return dataset;
                
            }
        }


    }
}
