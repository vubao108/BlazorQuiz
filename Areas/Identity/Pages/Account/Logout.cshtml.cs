using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using BlazorVNPTQuiz.Services;

namespace BlazorVNPTQuiz.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class LogoutModel : PageModel
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ILogger<LogoutModel> _logger;
        private readonly AppState appState;

        public LogoutModel(SignInManager<IdentityUser> signInManager, ILogger<LogoutModel> logger, AppState appState)
        {
            _signInManager = signInManager;
            _logger = logger;
            this.appState = appState;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost(string returnUrl = null)
        {
            _logger.LogInformation($"userId:{appState.CurrentIdentityUserId} logging out");
            await _signInManager.SignOutAsync();
            appState.CurrentIdentityUserId = 0;
            _logger.LogInformation($"User logged out. ");
            if (returnUrl != null)
            {
                return LocalRedirect(returnUrl);
            }
            else
            {
                return RedirectToPage("Login");
            }
        }
    }
}
