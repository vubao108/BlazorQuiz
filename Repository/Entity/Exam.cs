using System;
using System.Collections.Generic;

#nullable disable

namespace BlazorVNPTQuiz.Repository.Entity
***REMOVED***
    public partial class Exam
    ***REMOVED***
        public Exam()
        ***REMOVED***
            UserExams = new HashSet<UserExam>();
    ***REMOVED***

        public long Id ***REMOVED*** get; set; ***REMOVED***
        public string Name ***REMOVED*** get; set; ***REMOVED***
        public int NumOfQuestion ***REMOVED*** get; set; ***REMOVED***
        public int? MaxTry ***REMOVED*** get; set; ***REMOVED***
        public sbyte? Enable ***REMOVED*** get; set; ***REMOVED***
        public DateTime? StartTime ***REMOVED*** get; set; ***REMOVED***
        public DateTime? EndTime ***REMOVED*** get; set; ***REMOVED***
        public int? Duration ***REMOVED*** get; set; ***REMOVED***
        public sbyte? Type ***REMOVED*** get; set; ***REMOVED***
        public sbyte? Official ***REMOVED*** get; set; ***REMOVED***
        public int DonviId ***REMOVED*** get; set; ***REMOVED***

        public virtual ICollection<UserExam> UserExams ***REMOVED*** get; set; ***REMOVED***
***REMOVED***
***REMOVED***
