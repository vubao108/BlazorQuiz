using BlazorVNPTQuiz.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorVNPTQuiz.Services
***REMOVED***
    public class AppState
    ***REMOVED***
        public event Action<ComponentBase, string> StateChanged;

        private void NotifyStateChanged(ComponentBase Source, string Property) => StateChanged?.Invoke(Source, Property);

        public ExamInfo SelectedExamInfo ***REMOVED***get;private set;***REMOVED***

        public void UpdateSelectedExam(ComponentBase source, ExamInfo examInfo )
        ***REMOVED***
            this.SelectedExamInfo = examInfo;
            NotifyStateChanged(source, "SelectedExamInfo");
    ***REMOVED***

***REMOVED***
***REMOVED***
