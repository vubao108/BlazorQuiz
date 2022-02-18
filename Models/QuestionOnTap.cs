using System.Collections.Generic;

namespace BlazorVNPTQuiz.Models
{
    public class QuestionOnTap
    {
        public int Id;
        public int UserId { get; set; }
        public int QuestionId { get; set; }
        public string QuestionText { get; set; }

        public int LevelId { get; set; }
        public int TagId { get; set; }
        public bool IsMultipleChoice { get; set; }
        public List<AnswerDAO> Answers {get;set;}
    }
}
