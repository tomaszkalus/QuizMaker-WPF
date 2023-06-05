using QuizMaker.Models;
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
    internal class CreateNewQuestionCommand : CommandBase
    {
        private NavigationStore _navigationStore;
        private NavigationService _createAnswersEditViewModel;
        private QuizCollection _quizCollection;

        public override void Execute(object? parameter)
        {
        }

        public CreateNewQuestionCommand(NavigationService createAnswersEditViewModel)
        {
            _createAnswersEditViewModel = createAnswersEditViewModel;
            
        }
    }
}
