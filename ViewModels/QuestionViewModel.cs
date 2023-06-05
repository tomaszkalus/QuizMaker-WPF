using QuizMaker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizMaker.ViewModels
{
    public class QuestionViewModel : ViewModelBase
    {
        private readonly Question _question;
        public string Text => _question.Text;
        public string Order=> _question.Order.ToString();
        public string QuestionId => _question.QuestionId.ToString();

        public QuestionViewModel(Question question)
        {
            _question = question;  
        }
    }

    
}
