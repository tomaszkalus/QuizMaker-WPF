using QuizMaker.Services;
using QuizMaker.Stores;
using QuizMaker.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizMaker.Commands
{
    public class NavigateCommand : CommandBase
    {

        private readonly NavigationService _navigationService;

        public NavigateCommand(NavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public override void Execute(object? parameter)
        {
            _navigationService.Navigate();

        }
    }
}
