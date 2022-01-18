using System;
using System.Collections.Generic;

#nullable disable

namespace BlazorVNPTQuiz.Repository.Entity
{
    public partial class LogQuestion
    {
        public int Id { get; set; }
        public sbyte? Action { get; set; }
        public int? QuestionId { get; set; }
        public int? OldQuestionId { get; set; }
        public int? TagId { get; set; }
        public DateTime? CreatedTime { get; set; }
    }
}
