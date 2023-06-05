using QuizMaker.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizMaker.Commands
{
    public class CancelCreateQuestionCommand : CommandBase
    {
        private NavigationService _createQuizesListViewModel;

        public override void Execute(object? parameter)
        {
            throw new NotImplementedException();
        }

        public CancelCreateQuestionCommand(NavigationService createQuizesListViewModel)
        {
            _createQuizesListViewModel = createQuizesListViewModel;
            
        }
    }
}
