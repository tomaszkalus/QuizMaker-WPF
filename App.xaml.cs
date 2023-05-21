using QuizMaker.DB;
using QuizMaker.DB.Repositories;
using QuizMaker.Models;
using QuizMaker.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;

namespace QuizMaker
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            string conn_string = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            //AnswerRepository answerRepo = new AnswerRepository(conn_string);
            //List<Answer> answers = answerRepo.GetAnswersByQuestionID(2);
            //Answer answer = new Answer("test", false, 2, 25);
            //answerRepo.UpdateAnswer(answer);

            List<Answer> answer_list = new List<Answer>();
            Answer answer1 = new Answer("test odp01", true, 1);
            Answer answer2 = new Answer("test odp02", false, 2);
            Answer answer3 = new Answer("test odp03", false, 3);
            Answer answer4 = new Answer("test odp04", false, 4);
            answer_list.Add(answer1); answer_list.Add(answer2); answer_list.Add(answer3); answer_list.Add(answer4);

            Question question = new Question("test pytanie 01", answer_list, 3, 8);
            QuestionRepository questionRepository = new QuestionRepository(conn_string);
            //questionRepository.AddQuestion(question, 3);

            //questionRepository.DeleteQuestion(question);

            Question question2 = questionRepository.GetQuestionByID(5);







            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel()
            };
            MainWindow.Show();

            base.OnStartup(e);


        }
    }
}
