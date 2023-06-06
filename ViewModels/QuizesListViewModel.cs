using QuizMaker.Commands;
using QuizMaker.Models;
using QuizMaker.Services;
using QuizMaker.Stores;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace QuizMaker.ViewModels
{
    public class QuizesListViewModel : ViewModelBase
    {
        private readonly QuizCollection _quizCollection;
        private readonly QuizStore _quizStore;
        private readonly ObservableCollection<QuizViewModel> _quizes;
        private QuizViewModel _selectedQuiz;
        public IEnumerable<QuizViewModel> Quizes => _quizes;
        public ICommand SaveToDBCommand { get; }
        public ICommand NewQuizCommand { get; }
        public ICommand DeleteQuizCommand { get; }
        public ICommand EditQuizCommand { get; }

        public QuizViewModel SelectedQuiz
        {
            get { return _selectedQuiz; }
            set
            {
                _selectedQuiz = value;
                OnPropertyChanged(nameof(SelectedQuiz));
            }
        }

        public QuizesListViewModel(QuizCollection quizCollection, QuizStore quizStore, string dbPath, NavigationService createQuizNameEditViewModel, NavigationService createQuestionsListViewModel)
        {
            _quizCollection = quizCollection;
            _quizStore = quizStore;
            _quizes = new ObservableCollection<QuizViewModel>();

            NewQuizCommand = new NavigateCommand(createQuizNameEditViewModel);
            EditQuizCommand = new EditQuizCommand(this, _quizCollection, createQuestionsListViewModel, _quizStore);
            DeleteQuizCommand = new DeleteQuizCommand(this, _quizCollection, UpdateQuizes);
            SaveToDBCommand = new SaveQuizesToDatabaseCommand(quizCollection);

            UpdateQuizes();

        }

        private void UpdateQuizes()
        {
            _quizes.Clear();
            foreach (var quiz in _quizCollection.GetAllQuizes())
            {
                QuizViewModel quizViewModel = new QuizViewModel(quiz);
                _quizes.Add(quizViewModel);
            }
        }


    }
}
