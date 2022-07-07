using System;
using System.Collections.Generic;

#nullable disable

namespace BlazorVNPTQuiz.Repository.Entity
{
    public partial class ExamQuestion
    {
        public long Id { get; set; }
        public long? ExamId { get; set; }
        public int? TryNum { get; set; }
        public long? UserId { get; set; }
        public long? QuestionId { get; set; }
        public long? AnswerId { get; set; }
    }
}
