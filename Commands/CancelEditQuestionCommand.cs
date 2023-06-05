using QuizMaker.Services;
using QuizMaker.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizMaker.Commands
{
    public class CancelEditQuestionCommand : CommandBase
    {
        private readonly NavigationService _createQuestionsListViewModel;
        private readonly QuestionStore _questionStore;

        public override void Execute(object? parameter)
        {
            _questionStore.CurrentQuestion = null;
            _createQuestionsListViewModel.Navigate();
        }

        public CancelEditQuestionCommand(NavigationService createQuestionsListViewModel, QuestionStore questionStore)
        {
            _questionStore = questionStore;
            _createQuestionsListViewModel = createQuestionsListViewModel;
            
            
        }
    }
}
