using System;
using System.Collections.Generic;

#nullable disable

namespace BlazorVNPTQuiz.Repository.Entity
{
    public partial class UserOntap
    {
        public int UserId { get; set; }
        public DateTime FinishedTime { get; set; }
        public int? NumRight { get; set; }
        public int? TotalNum { get; set; }
    }
}
