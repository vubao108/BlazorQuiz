using BlazorVNPTQuiz.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorVNPTQuiz.Services
{
    public class AppState
    {
        public event Action<ComponentBase, string> StateChanged;

        private void NotifyStateChanged(ComponentBase Source, string Property) => StateChanged?.Invoke(Source, Property);

        public ExamInfo SelectedExamInfo {get;private set;}

        public void UpdateSelectedExam(ComponentBase source, ExamInfo examInfo )
        {
            this.SelectedExamInfo = examInfo;
            NotifyStateChanged(source, "SelectedExamInfo");
        }

    }
}
