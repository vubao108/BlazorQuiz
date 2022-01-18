using System;
using System.Collections.Generic;

#nullable disable

namespace BlazorVNPTQuiz.Repository.Entity
{
    public partial class LogExam
    {
        public long Id { get; set; }
        public int ExamId { get; set; }
        public int UserId { get; set; }
        public int TryNum { get; set; }
        public DateTime LoginTime { get; set; }
        public string PhoneNumber { get; set; }
        public string ImeiNumber { get; set; }
        public int? SdkVersion { get; set; }
    }
}
