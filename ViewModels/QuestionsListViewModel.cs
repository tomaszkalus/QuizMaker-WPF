using QuizMaker.Commands;
using QuizMaker.Models;
using QuizMaker.Services;
using QuizMaker.Stores;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace QuizMaker.ViewModels
{
    public class QuestionsListViewModel : ViewModelBase
    {
        private readonly ObservableCollection<QuestionViewModel> _questions;

        private readonly QuizStore _quizStore;

        private QuestionViewModel _selectedQuestion;
        public QuestionViewModel SelectedQuestion
        {
            get { return _selectedQuestion; }
            set
            {
                _selectedQuestion = value;
                OnPropertyChanged(nameof(SelectedQuestion));
            }
        }

        public string QuizName => _quizStore.CurrentQuiz.QuizName;
        public IEnumerable<QuestionViewModel> Questions => _questions;
        public ICommand BackToQuizesCommand { get; }
        public ICommand AddQuestionCommand { get; }
        public ICommand EditQuestionCommand { get; }
        public ICommand DeleteQuestionCommand { get; }



        public QuestionsListViewModel(QuizStore quizStore, QuestionStore questionStore, NavigationService createAnswersEditViewModel, NavigationService createQuizesListViewModel)
        {

            _quizStore = quizStore;
            _questions = new ObservableCollection<QuestionViewModel>();

            BackToQuizesCommand = new NavigateCommand(createQuizesListViewModel);

            AddQuestionCommand = new NavigateCommand(createAnswersEditViewModel);

            EditQuestionCommand = new EditQuestionCommand(this, _quizStore, questionStore, createAnswersEditViewModel);

            DeleteQuestionCommand = new DeleteQuestionCommand(this, _quizStore, UpdateQuestions);



            UpdateQuestions();





        }

        private void UpdateQuestions()
        {
            _questions.Clear();

            foreach (var question in GetSortedQuestions())
            {
                _questions.Add(new QuestionViewModel(question));
            }

        }
        private List<Question> GetSortedQuestions()
        {
            var questions = _quizStore.CurrentQuiz.GetAllQuestions();
            return questions.OrderBy(x => x.Order).ToList();
        }
    }
}
