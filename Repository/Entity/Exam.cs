using System;
using System.Collections.Generic;

#nullable disable

namespace BlazorVNPTQuiz.Repository.Entity
{
    public partial class Exam
    {
        public Exam()
        {
            UserExams = new HashSet<UserExam>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public int NumOfQuestion { get; set; }
        public int? MaxTry { get; set; }
        public sbyte? Enable { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public int? Duration { get; set; }
        public sbyte? Type { get; set; }
        public sbyte? Official { get; set; }
        public int DonviId { get; set; }

        public virtual ICollection<UserExam> UserExams { get; set; }
    }
}
