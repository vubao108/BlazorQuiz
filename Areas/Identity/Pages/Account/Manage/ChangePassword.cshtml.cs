using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
namespace BlazorVNPTQuiz.Areas.Identity.Pages.Account.Manage
***REMOVED***
    public class ChangePasswordModel : PageModel
    ***REMOVED***
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ILogger<ChangePasswordModel> _logger;

        public ChangePasswordModel(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            ILogger<ChangePasswordModel> logger)
        ***REMOVED***
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
    ***REMOVED***

        [BindProperty]
        public InputModel Input ***REMOVED*** get; set; ***REMOVED***

        [TempData]
        public string StatusMessage ***REMOVED*** get; set; ***REMOVED***

        public class InputModel
        ***REMOVED***
            [Required]
            [DataType(DataType.Password)]
            [Display(Name = "Current password")]
            public string OldPassword ***REMOVED*** get; set; ***REMOVED***

            [Required]
            [StringLength(100, ErrorMessage = "The ***REMOVED***0***REMOVED*** must be at least ***REMOVED***2***REMOVED*** and at max ***REMOVED***1***REMOVED*** characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "New password")]
            public string NewPassword ***REMOVED*** get; set; ***REMOVED***

            [DataType(DataType.Password)]
            [Display(Name = "Confirm new password")]
            [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
            public string ConfirmPassword ***REMOVED*** get; set; ***REMOVED***
    ***REMOVED***

        public async Task<IActionResult> OnGetAsync()
        ***REMOVED***
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            ***REMOVED***
                return NotFound($"Unable to load user with ID '***REMOVED***_userManager.GetUserId(User)***REMOVED***'.");
        ***REMOVED***

            var hasPassword = await _userManager.HasPasswordAsync(user);
            if (!hasPassword)
            ***REMOVED***
                return RedirectToPage("./SetPassword");
        ***REMOVED***

            return Page();
    ***REMOVED***

        public async Task<IActionResult> OnPostAsync()
        ***REMOVED***
            if (!ModelState.IsValid)
            ***REMOVED***
                return Page();
        ***REMOVED***

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            ***REMOVED***
                return NotFound($"Unable to load user with ID '***REMOVED***_userManager.GetUserId(User)***REMOVED***'.");
        ***REMOVED***

            var changePasswordResult = await _userManager.ChangePasswordAsync(user, Input.OldPassword, Input.NewPassword);
            if (!changePasswordResult.Succeeded)
            ***REMOVED***
                foreach (var error in changePasswordResult.Errors)
                ***REMOVED***
                    ModelState.AddModelError(string.Empty, error.Description);
            ***REMOVED***
                return Page();
        ***REMOVED***

            await _signInManager.RefreshSignInAsync(user);
            _logger.LogInformation("User changed their password successfully.");
            StatusMessage = "Your password has been changed.";

            return RedirectToPage();
    ***REMOVED***
***REMOVED***
***REMOVED***
