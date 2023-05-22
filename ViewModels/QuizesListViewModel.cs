using QuizMaker.Commands;
using QuizMaker.Models;
using QuizMaker.Stores;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace QuizMaker.ViewModels
{
    public class QuizesListViewModel : ViewModelBase
    {
        private readonly ObservableCollection<QuizViewModel> _quizes;
        private readonly NavigationStore _navigationStore;
        public IEnumerable<QuizViewModel> Quizes => _quizes;
        public ICommand SaveToDBCommand { get; }
        public ICommand NewQuizCommand { get; }
        public ICommand DeleteQuizCommand { get; }
        public ICommand EditQuizCommand { get; }

        public QuizesListViewModel(NavigationStore navigationStore)
        {
            NewQuizCommand = new CreateNewQuizCommand();
            _navigationStore = navigationStore;


            //_quizes = new ObservableCollection<QuizViewModel>();
            //_quizes.Add(new QuizViewModel(new Models.Quiz(new List<Question>(), 1, "Filmy")));
            //_quizes.Add(new QuizViewModel(new Models.Quiz(new List<Question>(), 2, "Muzyka")));
            //_quizes.Add(new QuizViewModel(new Models.Quiz(new List<Question>(), 3, "Programowanie")));
            //_quizes.Add(new QuizViewModel(new Models.Quiz(new List<Question>(), 4, "Historia")));

        }

    }
}
