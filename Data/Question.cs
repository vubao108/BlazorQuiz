using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorVNPTQuiz.Data
{
    public class Question
    {
        public int QuestionId { get; set; }
        public string QuextionText { get; set; }

        public List<Answer> answers { get; set; }
    }

    public class Answer
    {
        public int AnswerId { get; set; }
        public string AnswerText { get; set; }
        public bool IsCorrect { get; set; }
    }
}
