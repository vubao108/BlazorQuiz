using System;
using System.Collections.Generic;

#nullable disable

namespace BlazorVNPTQuiz.Repository.Entity
{
    public partial class Question
    {
        public ulong QuestionId { get; set; }
        public string QuestionText { get; set; }
        public int Level { get; set; }
        public sbyte? Enable { get; set; }
    }
}
