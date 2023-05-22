using QuizMaker.Commands;
using QuizMaker.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace QuizMaker.ViewModels
{
    public class StartPageViewModel : ViewModelBase
    {
        public ICommand CreateDatabaseCommand { get; }
        public ICommand OpenDatabaseCommand { get; }

        public StartPageViewModel(NavigationStore navigationStore, Func<ViewModelBase> createViewModel )
        {
            CreateDatabaseCommand = new CreateDatabaseCommand();
            OpenDatabaseCommand = new NavigateCommand(navigationStore, createViewModel);

        }
    }
}
