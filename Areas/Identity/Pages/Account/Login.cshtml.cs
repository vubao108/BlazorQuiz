﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using BlazorVNPTQuiz.Services;

namespace BlazorVNPTQuiz.Areas.Identity.Pages.Account
***REMOVED***
    [AllowAnonymous]
    public class LoginModel : PageModel
    ***REMOVED***
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ILogger<LoginModel> _logger;
        private readonly AppState _appState;

        public LoginModel(SignInManager<IdentityUser> signInManager, 
            ILogger<LoginModel> logger,
            UserManager<IdentityUser> userManager, AppState appState)
        ***REMOVED***
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _appState = appState;
    ***REMOVED***

        [BindProperty]
        public InputModel Input ***REMOVED*** get; set; ***REMOVED***

        public IList<AuthenticationScheme> ExternalLogins ***REMOVED*** get; set; ***REMOVED***

        public string ReturnUrl ***REMOVED*** get; set; ***REMOVED***

        [TempData]
        public string ErrorMessage ***REMOVED*** get; set; ***REMOVED***

        public class InputModel
        ***REMOVED***
            [Required]
            [DataType(DataType.Text)]
            [Display(Name ="Tài khoản")]
            public string UserName ***REMOVED*** get; set; ***REMOVED***

            [Required]
            [DataType(DataType.Password)]
            [Display(Name = "Mật khẩu")]
            public string Password ***REMOVED*** get; set; ***REMOVED***

            [Display(Name = "Lưu thông tin đăng nhập?")]
            public bool RememberMe ***REMOVED*** get; set; ***REMOVED***
    ***REMOVED***

        public async Task OnGetAsync(string returnUrl = null)
        ***REMOVED***
            if (!string.IsNullOrEmpty(ErrorMessage))
            ***REMOVED***
                ModelState.AddModelError(string.Empty, ErrorMessage);
        ***REMOVED***

            returnUrl ??= Url.Content("~/");

            // Clear the existing external cookie to ensure a clean login process
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            ReturnUrl = returnUrl;
    ***REMOVED***

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        ***REMOVED***
            returnUrl ??= Url.Content("~/");

            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        
            if (ModelState.IsValid)
            ***REMOVED***
                // This doesn't count login failures towards account lockout
                // To enable password failures to trigger account lockout, set lockoutOnFailure: true
                //var result = await _signInManager.PasswordSignInAsync(Input.UserName, Input.Password, Input.RememberMe, lockoutOnFailure: false);
                var dbUser = _userManager.Users.FirstOrDefault(user => user.UserName == Input.UserName && user.PasswordHash == Input.Password);
              
                if (dbUser != null)
                ***REMOVED***

                     await _signInManager.SignInAsync(dbUser, Input.RememberMe);
                    _appState.CurrentIdentityUserId = Convert.ToInt32(dbUser.Id);
                    _logger.LogInformation($"User logged in: ***REMOVED***dbUser.UserName***REMOVED*** userId= ***REMOVED***_appState.CurrentIdentityUserId***REMOVED***");
                    return LocalRedirect(returnUrl);
            ***REMOVED***
                //if (result.RequiresTwoFactor)
                //***REMOVED***
                //    return RedirectToPage("./LoginWith2fa", new ***REMOVED*** ReturnUrl = returnUrl, RememberMe = Input.RememberMe ***REMOVED***);
                //***REMOVED***
                //if (result.IsLockedOut)
                //***REMOVED***
                //    _logger.LogWarning("User account locked out.");
                //    return RedirectToPage("./Lockout");
                //***REMOVED***
                else
                ***REMOVED***
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return Page();
            ***REMOVED***
        ***REMOVED***

            // If we got this far, something failed, redisplay form
            return Page();
    ***REMOVED***
***REMOVED***
***REMOVED***
