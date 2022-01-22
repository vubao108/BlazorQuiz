using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace BlazorVNPTQuiz.Areas.Identity.Pages.Account
***REMOVED***
    [AllowAnonymous]
    public class LogoutModel : PageModel
    ***REMOVED***
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ILogger<LogoutModel> _logger;

        public LogoutModel(SignInManager<IdentityUser> signInManager, ILogger<LogoutModel> logger)
        ***REMOVED***
            _signInManager = signInManager;
            _logger = logger;
    ***REMOVED***

        public void OnGet()
        ***REMOVED***
    ***REMOVED***

        public async Task<IActionResult> OnPost(string returnUrl = null)
        ***REMOVED***
            await _signInManager.SignOutAsync();
            _logger.LogInformation("User logged out.");
            if (returnUrl != null)
            ***REMOVED***
                return LocalRedirect(returnUrl);
        ***REMOVED***
            else
            ***REMOVED***
                return RedirectToPage("Login");
        ***REMOVED***
    ***REMOVED***
***REMOVED***
***REMOVED***
