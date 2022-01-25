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
***REMOVED***
    public class AppState : IDisposable
    ***REMOVED***
        public AppState()
        ***REMOVED***
            StartTimer();
           

    ***REMOVED***
        private Timer timer;
        public event Action<ComponentBase, string> StateChanged;

        private void NotifyStateChanged(ComponentBase Source, string Property) => StateChanged?.Invoke(Source, Property);

        public int  CurrentIdentityUserId ***REMOVED*** get; set; ***REMOVED***
        public ExamInfo SelectedExamInfo ***REMOVED***get;private set;***REMOVED***
        public int RemainSeconds ***REMOVED*** get; private set; ***REMOVED*** = 0;

        

        public void UpdateSelectedExam(ComponentBase source, ExamInfo examInfo )
        ***REMOVED***
            this.SelectedExamInfo = examInfo;
            NotifyStateChanged(source, "SelectedExamInfo");
    ***REMOVED***

        public void UpdateRemainSeconds(ComponentBase source, int RemainSeconds)
        ***REMOVED***
            this.RemainSeconds = RemainSeconds;
           
            NotifyStateChanged(source, "RemainSeconds");
    ***REMOVED***

       

        public void StartTimer()
        ***REMOVED***
            Debug.Print("AppState.StartTimer()");
            timer = new Timer(1000);
            timer.Elapsed += OnTimedEvent;
            timer.Enabled = true;
    ***REMOVED***
        void ReleaseTimer()
        ***REMOVED***
            
            timer?.Stop();
            
            timer?.Dispose();
    ***REMOVED***
        private void OnTimedEvent(object sender, ElapsedEventArgs e)
        ***REMOVED***
            
            if (--RemainSeconds >= 0)
            ***REMOVED***
                UpdateRemainSeconds(null, RemainSeconds);
        ***REMOVED***
            
    ***REMOVED***

        
        public void Dispose()
        ***REMOVED***
            Debug.Print("AppState.Dispose()");
            ReleaseTimer();
            
    ***REMOVED***
***REMOVED***
***REMOVED***
