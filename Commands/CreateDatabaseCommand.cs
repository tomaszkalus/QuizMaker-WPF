using QuizMaker.Models;
using QuizMaker.Services;
using QuizMaker.Stores;
using QuizMaker.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizMaker.Commands
{
    public class CreateDatabaseCommand : CommandBase
    {
        private readonly QuizCollection _quizCollection;
        private readonly NavigationService _makeQuizesListViewNavigationService;
        private readonly NavigationStore _navigationStore;

        public override void Execute(object? parameter)
        {

            //_makeQuizesListViewNavigationService.Navigate();
            //_navigationStore.CurrentViewModel = new QuizesListViewModel(_quizCollection, _navigationStore);

        }

        public CreateDatabaseCommand(QuizCollection quizCollection, NavigationStore navigationStore)
        {
            _quizCollection = quizCollection;
            _navigationStore = navigationStore;
        }
    }
}
