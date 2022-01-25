using BlazorVNPTQuiz.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;
using System.Diagnostics;
using Microsoft.AspNetCore.Identity;

namespace BlazorVNPTQuiz.Services
{
    public class AppState : IDisposable
    {
        public AppState()
        {
            StartTimer();
           

        }
        private Timer timer;
        public event Action<ComponentBase, string> StateChanged;

        private void NotifyStateChanged(ComponentBase Source, string Property) => StateChanged?.Invoke(Source, Property);

        public int  CurrentIdentityUserId { get; set; }
        public ExamInfo SelectedExamInfo {get;private set;}
        public int RemainSeconds { get; private set; } = 0;

        

        public void UpdateSelectedExam(ComponentBase source, ExamInfo examInfo )
        {
            this.SelectedExamInfo = examInfo;
            NotifyStateChanged(source, "SelectedExamInfo");
        }

        public void UpdateRemainSeconds(ComponentBase source, int RemainSeconds)
        {
            this.RemainSeconds = RemainSeconds;
           
            NotifyStateChanged(source, "RemainSeconds");
        }

       

        public void StartTimer()
        {
            Debug.Print("AppState.StartTimer()");
            timer = new Timer(1000);
            timer.Elapsed += OnTimedEvent;
            timer.Enabled = true;
        }
        void ReleaseTimer()
        {
            
            timer?.Stop();
            
            timer?.Dispose();
        }
        private void OnTimedEvent(object sender, ElapsedEventArgs e)
        {
            
            if (--RemainSeconds >= 0)
            {
                UpdateRemainSeconds(null, RemainSeconds);
            }
            
        }

        
        public void Dispose()
        {
            Debug.Print("AppState.Dispose()");
            ReleaseTimer();
            
        }
    }
}
