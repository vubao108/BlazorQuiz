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
namespace BlazorVNPTQuiz.Services
{
    public class AppState : IDisposable
    {
        private readonly AuthenticationStateProvider authenticationStateProvider;
        private readonly UserManager<IdentityUser> userManager;
        public AppState(AuthenticationStateProvider authenticationStateProvider, UserManager<IdentityUser> userManager)
        {
            StartTimer();

            this.authenticationStateProvider = authenticationStateProvider;
            this.userManager = userManager;
            CurrentIdentityUserId = GetUserId();
        }

        private async Task<int> GetUserId()
        {
            var authState = await authenticationStateProvider.GetAuthenticationStateAsync();
            if (authState.User.Identity.IsAuthenticated)
            {
                var user = userManager.Users.FirstOrDefault(item=>item.UserName == authState.User.Identity.Name);
                
                Debug.Print($"AppState.InitialUserId() : {user.Id}");
                return Convert.ToInt32(user.Id);
            }
            return 0;
        }


        private Timer timer;
        public event Action<ComponentBase, string> StateChanged;

        private void NotifyStateChanged(ComponentBase Source, string Property) => StateChanged?.Invoke(Source, Property);

        public Task<int>  CurrentIdentityUserId { get; set; }
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
