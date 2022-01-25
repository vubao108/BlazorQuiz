using BlazorVNPTQuiz.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;
using System.Diagnostics;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Components.Authorization;
namespace BlazorVNPTQuiz.Services
***REMOVED***
    public class AppState : IDisposable
    ***REMOVED***
        private readonly AuthenticationStateProvider authenticationStateProvider;
        private readonly UserManager<IdentityUser> userManager;
        public AppState(AuthenticationStateProvider authenticationStateProvider, UserManager<IdentityUser> userManager)
        ***REMOVED***
            StartTimer();

            this.authenticationStateProvider = authenticationStateProvider;
            this.userManager = userManager;
            CurrentIdentityUserId = GetUserId();
    ***REMOVED***

        private async Task<int> GetUserId()
        ***REMOVED***
            var authState = await authenticationStateProvider.GetAuthenticationStateAsync();
            if (authState.User.Identity.IsAuthenticated)
            ***REMOVED***
                var user = userManager.Users.FirstOrDefault(item=>item.UserName == authState.User.Identity.Name);
                
                Debug.Print($"AppState.InitialUserId() : ***REMOVED***user.Id***REMOVED***");
                return Convert.ToInt32(user.Id);
        ***REMOVED***
            return 0;
    ***REMOVED***


        private Timer timer;
        public event Action<ComponentBase, string> StateChanged;

        private void NotifyStateChanged(ComponentBase Source, string Property) => StateChanged?.Invoke(Source, Property);

        public Task<int>  CurrentIdentityUserId ***REMOVED*** get; set; ***REMOVED***
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
