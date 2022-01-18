using System;
using System.Collections.Generic;

#nullable disable

namespace BlazorVNPTQuiz.Repository.Entity
{
    public partial class UserExam
    {
        public ulong Id { get; set; }
        public long? UserId { get; set; }
        public long? ExamId { get; set; }
        public int? TryNum { get; set; }
        public DateTime? JoinTime { get; set; }
        public DateTime? FinishedTime { get; set; }
        public long? NumOfRight { get; set; }
        public sbyte? State { get; set; }
        public string Note { get; set; }
        public sbyte? Official { get; set; }

        public virtual Exam Exam { get; set; }
    }
}
