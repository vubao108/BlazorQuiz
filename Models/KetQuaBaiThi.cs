using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorVNPTQuiz.Models
***REMOVED***
    public class KetQuaBaiThi
    ***REMOVED***
        public int UserExamId ***REMOVED*** get; set; ***REMOVED***
        public UserInfo User ***REMOVED*** get; set; ***REMOVED***
        public ExamInfo Exam ***REMOVED*** get; set; ***REMOVED***
        public decimal Score ***REMOVED*** get; set; ***REMOVED***
        public int NumOfRight ***REMOVED*** get; set; ***REMOVED***
        public DateTime JoinTime ***REMOVED*** get; set; ***REMOVED***
        public DateTime FinishTime ***REMOVED*** get; set; ***REMOVED***
        public int TryNum ***REMOVED*** get; set; ***REMOVED***
***REMOVED***

    public class ExamNotFinishedYet ***REMOVED*** 
        public int UserExamId ***REMOVED*** get; set; ***REMOVED***
        public ExamInfo CurrentExam ***REMOVED*** get; set; ***REMOVED***
        public int RemainSecond ***REMOVED*** get; set; ***REMOVED***
        public DateTime JoinTime ***REMOVED*** get; set; ***REMOVED***
        public int TryNum ***REMOVED*** get; set; ***REMOVED***
    
***REMOVED***


    public class ExamInfo
    ***REMOVED***
        public int ExamId ***REMOVED*** get; set; ***REMOVED***
        public int MaxTry ***REMOVED*** get; set; ***REMOVED***
        public string ExamName ***REMOVED*** get; set; ***REMOVED***

        public int Duration ***REMOVED*** get; set; ***REMOVED***
        public int NumOfQuestion ***REMOVED*** get; set; ***REMOVED***
***REMOVED***

    public class UserInfo
    ***REMOVED***
        public int UserId;
        public string UserName;
        public string FullName;
        public string TenDonVi;
***REMOVED***
***REMOVED***
