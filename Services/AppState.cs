using BlazorVNPTQuiz.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Components.Authorization;
using BlazorVNPTQuiz.Repository;
namespace BlazorVNPTQuiz.Services
***REMOVED***
    public class AppState : IDisposable
    ***REMOVED***
        private readonly AuthenticationStateProvider authenticationStateProvider;
        private readonly UserManager<IdentityUser> userManager;
        private readonly IRepository repository;
        public AppState(AuthenticationStateProvider authenticationStateProvider
            , UserManager<IdentityUser> userManager, IRepository repository)
        ***REMOVED***
            

            this.authenticationStateProvider = authenticationStateProvider;
            this.userManager = userManager;
            this.repository = repository;
            //CurrentIdentityUserId = GetUserId();
            //SelectedExamNotFinishedInfo = GetCurrentExam();
            StartTimer();
    ***REMOVED***
        public async Task InitializeState()
        ***REMOVED***
            await GetUserId();
            await GetCurrentExam();
    ***REMOVED***

        private async Task  GetCurrentExam()
        ***REMOVED***
            if(CurrentIdentityUserId <= 0)
            ***REMOVED***
                await GetUserId();
        ***REMOVED***
            if (CurrentIdentityUserId > 0)
            ***REMOVED***
                SelectedExamNotFinishedInfo = await repository.LayBaiThiDangLam(CurrentIdentityUserId);
                UpdateRemainSeconds(null, SelectedExamNotFinishedInfo.RemainSecond);

        ***REMOVED***
            NotifyStateChanged(null, "SelectedExamNotFinishedInfo");
    ***REMOVED***
        private async Task GetUserId()
        ***REMOVED***

            var authState = await authenticationStateProvider.GetAuthenticationStateAsync();
            if (authState.User.Identity.IsAuthenticated)
            ***REMOVED***
                var user = userManager.Users.FirstOrDefault(item=>item.UserName == authState.User.Identity.Name);
                
                Debug.Print($"AppState.InitialUserId() : ***REMOVED***user.Id***REMOVED***");
                this.CurrentIdentityUserId =  Convert.ToInt32(user.Id);
        ***REMOVED***
            NotifyStateChanged(null, "CurrentIdentityUserId");
            //return 0;
    ***REMOVED***


        private Timer timer;
        public event Action<ComponentBase, string> StateChanged;

        private void NotifyStateChanged(ComponentBase Source, string Property) => StateChanged?.Invoke(Source, Property);

        public int  CurrentIdentityUserId ***REMOVED*** get; set; ***REMOVED***
        public ExamNotFinishedYet SelectedExamNotFinishedInfo ***REMOVED***get;private set;***REMOVED***
        public int RemainSeconds ***REMOVED*** get; private set; ***REMOVED*** = 0;

        

        public void UpdateSelectedExam(ComponentBase source, ExamNotFinishedYet examInfo )
        ***REMOVED***
            this.SelectedExamNotFinishedInfo = examInfo;
            NotifyStateChanged(source, "SelectedExamNotFinishedInfo");
    ***REMOVED***

        public void UpdateRemainSeconds(ComponentBase source, int RemainSeconds)
        ***REMOVED***
            this.RemainSeconds = RemainSeconds;
           
            NotifyStateChanged(source, "RemainSeconds");
    ***REMOVED***

       

        public void StartTimer()
        ***REMOVED***
            Debug.Print("AppState.StartTimer()");
            timer = new Timer((_) =>
            ***REMOVED***
                DecreaseTimer();
                    
                    
              
        ***REMOVED***, null, 0, 1000);
    ***REMOVED***
        void ReleaseTimer()
        ***REMOVED***
            
            
            
            timer?.Dispose();
    ***REMOVED***
        private void DecreaseTimer()
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
