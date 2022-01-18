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
    }


    public class QuestionDAO
    {
        public int ExamQuestionId { get; set; }
        public int QuestionId { get; set; }
        public string QuestionText { get; set; }
        public List<AnswerDAO> Answers { get; set; }
        public int UserAnswerId { get; set; }

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
