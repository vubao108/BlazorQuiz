using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorVNPTQuiz.Models
{
    public class QuestionUserExam
    {
        public int UserExamId { get; set; }
        public int ExamID { get; set; }

        public int UserId { get; set; }
        
        public int TryNum { get; set; }
        public int RemainSeCond { get; set; }


        public List<QuestionDAO> Questions { get; set; }


        public bool IsContainQuestion(QuestionDAO questionDAO)
        {
            if (Questions == null || Questions.Count() == 0)
                return false;
            else
                return Questions.Any(question => question.QuestionId == questionDAO.QuestionId);
        }

        public void AddQuestion(QuestionDAO questionDAO)
        {
            this.Questions.Add(questionDAO);
        }

        public QuestionDAO GetQuestion(int question_id)
        {
            return this.Questions.FirstOrDefault(item => item.QuestionId == question_id);
        }

        public (decimal,int) GetScore()
        {
            int numOfRightAnswer = this.Questions.Count(question => question.UserAnswerId == question.Answers.FirstOrDefault(ans => ans.IsCorrect).AnswerId);
            return (Convert.ToDecimal(numOfRightAnswer *10) / this.Questions.Count, numOfRightAnswer);
        }
    }


    public class QuestionDAO
    {
        public bool IsSyncUserAnswer { get; set; }
        public int ExamQuestionId { get; set; }
        public int QuestionId { get; set; }
        public string QuestionText { get; set; }
        public List<AnswerDAO> Answers { get; set; }
        private int _userAnswerId;
        public int UserAnswerId { get => _userAnswerId; set{
                if(value != _userAnswerId)
                {
                    IsSyncUserAnswer = false;
                    _userAnswerId = value;
                }
            } }

        public void AddAnswer(AnswerDAO answerDAO)
        {
            if (Answers == null)
                Answers = new List<AnswerDAO>();
            Answers.Add(answerDAO);
        }

       


    }

    public class AnswerDAO
    {
        public int AnswerId { get; set; }
        public String AnswerText { get; set; }
        public bool IsCorrect { get; set; }
    }
}
