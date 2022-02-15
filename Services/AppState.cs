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
{
    public class AppState : IDisposable
    {
        private readonly AuthenticationStateProvider authenticationStateProvider;
        private readonly UserManager<IdentityUser> userManager;
        private readonly IRepositoryExam repository;
        
        public AppState(AuthenticationStateProvider authenticationStateProvider
            , UserManager<IdentityUser> userManager, IRepositoryExam repository)
        {
            

            this.authenticationStateProvider = authenticationStateProvider;
            this.userManager = userManager;
            this.repository = repository;
            //CurrentIdentityUserId = GetUserId();
            //SelectedExamNotFinishedInfo = GetCurrentExam();
            StartTimer();
        }
        public async Task InitializeState()
        {
            await GetUserId();
            await GetCurrentExam();
            await GetJoinedExams();
        }

        private async Task  GetCurrentExam()
        {
            if(CurrentIdentityUserId <= 0)
            {
                await GetUserId();
            }
            if (CurrentIdentityUserId > 0)
            {
                SelectedExamNotFinishedInfo = await repository.LayBaiThiDangLam(CurrentIdentityUserId);
                UpdateRemainSeconds(null, SelectedExamNotFinishedInfo.RemainSecond);

            }
            NotifyStateChanged(null, "SelectedExamNotFinishedInfo");
        }
        private async Task GetUserId()
        {

            var authState = await authenticationStateProvider.GetAuthenticationStateAsync();
            if (authState.User.Identity.IsAuthenticated)
            {
                var user = userManager.Users.FirstOrDefault(item=>item.UserName == authState.User.Identity.Name);
                
                Debug.Print($"AppState.InitialUserId() : {user.Id}");
                this.CurrentIdentityUserId =  Convert.ToInt32(user.Id);
            }
            NotifyStateChanged(null, "CurrentIdentityUserId");
            //return 0;
        }




        private Timer timer;
        public event Action<ComponentBase, string> StateChanged;

        private void NotifyStateChanged(ComponentBase Source, string Property) => StateChanged?.Invoke(Source, Property);

        public int  CurrentIdentityUserId { get; set; }
        public ExamNotFinishedYet SelectedExamNotFinishedInfo {get;private set;}
        public int RemainSeconds { get; private set; } = 0;
        public List<int> JoinedExamIds { get; private set; }

        public async Task GetJoinedExams()
        {
            JoinedExamIds = await repository.LayIdBaithiDaThamGia(CurrentIdentityUserId);
            NotifyStateChanged(null,"JoinedExamIds");
        }

        

        public void UpdateSelectedExam(ComponentBase source, ExamNotFinishedYet examInfo )
        {
            this.SelectedExamNotFinishedInfo = examInfo;
            NotifyStateChanged(source, "SelectedExamNotFinishedInfo");
        }

        public void UpdateRemainSeconds(ComponentBase source, int RemainSeconds)
        {
            this.RemainSeconds = RemainSeconds;
           
            NotifyStateChanged(source, "RemainSeconds");
        }

       

        public void StartTimer()
        {
            Debug.Print("AppState.StartTimer()");
            timer = new Timer((_) =>
            {
                DecreaseTimer();
                    
                    
              
            }, null, 0, 1000);
        }
        void ReleaseTimer()
        {
            
            
            
            timer?.Dispose();
        }
        private void DecreaseTimer()
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
