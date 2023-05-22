using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizMaker.Commands
{
    public class OpenDatabaseCommand : CommandBase
    {
        public override void Execute(object? parameter)
        {
            var dialog = new Microsoft.Win32.OpenFileDialog();
            dialog.FileName = "QuizDatabase";
            dialog.DefaultExt = ".db";
            dialog.Filter = "SQLite3 Database |*.db";

            bool? result = dialog.ShowDialog();

            if (result == true) 
            {
                // Open document
                string filename = dialog.FileName;
                Trace.WriteLine(filename);
            }

        }
    }
}
