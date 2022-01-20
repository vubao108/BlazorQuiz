using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;

namespace BlazorVNPTQuiz.Areas.Identity.Pages.Account
***REMOVED***
    [AllowAnonymous]
    public class RegisterModel : PageModel
    ***REMOVED***
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;

        public RegisterModel(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender)
        ***REMOVED***
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
    ***REMOVED***

        [BindProperty]
        public InputModel Input ***REMOVED*** get; set; ***REMOVED***

        public string ReturnUrl ***REMOVED*** get; set; ***REMOVED***

        public IList<AuthenticationScheme> ExternalLogins ***REMOVED*** get; set; ***REMOVED***

        public class InputModel
        ***REMOVED***
            [Required]
            //[EmailAddress]
            [Display(Name = "Tài khoản")]
            public string UserName ***REMOVED*** get; set; ***REMOVED***

            [Required]
            [StringLength(100, ErrorMessage = "The ***REMOVED***0***REMOVED*** must be at least ***REMOVED***2***REMOVED*** and at max ***REMOVED***1***REMOVED*** characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password ***REMOVED*** get; set; ***REMOVED***

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword ***REMOVED*** get; set; ***REMOVED***
    ***REMOVED***

        public async Task OnGetAsync(string returnUrl = null)
        ***REMOVED***
            ReturnUrl = returnUrl;
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
    ***REMOVED***

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        ***REMOVED***
            returnUrl ??= Url.Content("~/");
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            if (ModelState.IsValid)
            ***REMOVED***
                var user = new IdentityUser ***REMOVED*** UserName = Input.UserName , Email = Input.UserName ***REMOVED***;
                var result = await _userManager.CreateAsync(user, Input.Password);
                if (result.Succeeded)
                ***REMOVED***
                    _logger.LogInformation("User created a new account with password.");

                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new ***REMOVED*** area = "Identity", userId = user.Id, code = code, returnUrl = returnUrl ***REMOVED***,
                        protocol: Request.Scheme);

                   // await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                  //      $"Please confirm your account by <a href='***REMOVED***HtmlEncoder.Default.Encode(callbackUrl)***REMOVED***'>clicking here</a>.");

                    if (_userManager.Options.SignIn.RequireConfirmedAccount)
                    ***REMOVED***
                        //return RedirectToPage("RegisterConfirmation", new ***REMOVED*** email = Input.UserName, returnUrl = returnUrl ***REMOVED***);
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        return LocalRedirect(returnUrl);
                ***REMOVED***
                    else
                    ***REMOVED***
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        return LocalRedirect(returnUrl);
                ***REMOVED***
            ***REMOVED***
                foreach (var error in result.Errors)
                ***REMOVED***
                    ModelState.AddModelError(string.Empty, error.Description);
            ***REMOVED***
        ***REMOVED***

            // If we got this far, something failed, redisplay form
            return Page();
    ***REMOVED***
***REMOVED***
***REMOVED***
