using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorVNPTQuiz.Models
{
    public class KetQuaBaiThi
    {
        public int UserExamId { get; set; }
        public UserInfo User { get; set; }
        public ExamInfo Exam { get; set; }
        public decimal Score { get; set; }
        public int NumOfRight { get; set; }
        public DateTime JoinTime { get; set; }
        public DateTime FinishTime { get; set; }
        public int TryNum { get; set; }
    }

    public class ExamNotFinishedYet { 
        public int UserExamId { get; set; }
        public ExamInfo CurrentExam { get; set; }
        public int RemainSecond { get; set; }
        public DateTime JoinTime { get; set; }
        public int TryNum { get; set; }
    
    }


    public class ExamInfo
    {
        public int ExamId { get; set; }
        public int MaxTry { get; set; }
        public string ExamName { get; set; }

        public int Duration { get; set; }
        public int NumOfQuestion { get; set; }
    }

    public class UserInfo
    {
        public int UserId;
        public string UserName;
        public string FullName;
        public string TenDonVi;
    }
}
