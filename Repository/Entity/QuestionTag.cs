using System;
using System.Collections.Generic;

#nullable disable

namespace BlazorVNPTQuiz.Repository.Entity
{
    public partial class QuestionTag
    {
        public ulong Id { get; set; }
        public long QuestionId { get; set; }
        public int TagId { get; set; }
    }
}
