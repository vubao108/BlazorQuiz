using System;
using System.Collections.Generic;

#nullable disable

namespace BlazorVNPTQuiz.Repository.Entity
{
    public partial class QuestionAnswer
    {
        public long QaId { get; set; }
        public long QuestionId { get; set; }
        public long AnswerId { get; set; }
        public sbyte State { get; set; }
    }
}
