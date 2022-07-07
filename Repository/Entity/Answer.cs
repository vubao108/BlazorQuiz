using System;
using System.Collections.Generic;

#nullable disable

namespace BlazorVNPTQuiz.Repository.Entity
{
    public partial class Answer
    {
        public ulong AnswerId { get; set; }
        public string AnswerText { get; set; }
    }
}
