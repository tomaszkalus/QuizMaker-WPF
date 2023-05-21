using QuizMaker.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace QuizMaker.ViewModels
{
    public class QuestionsListViewModel : ViewModelBase
    {
        private readonly ObservableCollection<QuestionViewModel> _questions;
        public IEnumerable<QuestionViewModel> Questions => _questions;
        public ICommand CancelQuestionsCommand { get; }
        public ICommand AddQuestionCommand { get; }
        public ICommand EditQuestionCommand { get; }
        public ICommand DeleteQuestionCommand { get; }

        public QuestionsListViewModel()
        {
            _questions = new ObservableCollection<QuestionViewModel>();

            //_questions.Add(new QuestionViewModel(new Question(1, "Why did The Beatles broke up?", new Answer[4],1 )));
            //_questions.Add(new QuestionViewModel(new Question(2, "When was Nevermind released?", new Answer[4], 3)));
            //_questions.Add(new QuestionViewModel(new Question(1, "What's the best programming language?", new Answer[4], 2)));
        }
    }
}
