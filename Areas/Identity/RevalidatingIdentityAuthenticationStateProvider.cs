using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;


namespace BlazorVNPTQuiz.Areas.Identity
***REMOVED***
    public class RevalidatingIdentityAuthenticationStateProvider<TUser>
        : RevalidatingServerAuthenticationStateProvider where TUser : class
    ***REMOVED***
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly IdentityOptions _options;

        public RevalidatingIdentityAuthenticationStateProvider(
            ILoggerFactory loggerFactory,
            IServiceScopeFactory scopeFactory,
            IOptions<IdentityOptions> optionsAccessor)
            : base(loggerFactory)
        ***REMOVED***
            _scopeFactory = scopeFactory;
            _options = optionsAccessor.Value;
    ***REMOVED***

        protected override TimeSpan RevalidationInterval => TimeSpan.FromMinutes(30);

        protected override async Task<bool> ValidateAuthenticationStateAsync(
            AuthenticationState authenticationState, CancellationToken cancellationToken)
        ***REMOVED***
            // Get the user manager from a new scope to ensure it fetches fresh data
            var scope = _scopeFactory.CreateScope();
            try
            ***REMOVED***
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<TUser>>();
                return await ValidateSecurityStampAsync(userManager, authenticationState.User);
        ***REMOVED***
            finally
            ***REMOVED***
                if (scope is IAsyncDisposable asyncDisposable)
                ***REMOVED***
                    await asyncDisposable.DisposeAsync();
            ***REMOVED***
                else
                ***REMOVED***
                    scope.Dispose();
            ***REMOVED***
        ***REMOVED***
    ***REMOVED***

        private async Task<bool> ValidateSecurityStampAsync(UserManager<TUser> userManager, ClaimsPrincipal principal)
        ***REMOVED***
            var user = await userManager.GetUserAsync(principal);
            if (user == null)
            ***REMOVED***
                return false;
        ***REMOVED***
            else if (!userManager.SupportsUserSecurityStamp)
            ***REMOVED***
                return true;
        ***REMOVED***
            else
            ***REMOVED***
                var principalStamp = principal.FindFirstValue(_options.ClaimsIdentity.SecurityStampClaimType);
                var userStamp = await userManager.GetSecurityStampAsync(user);
                return principalStamp == userStamp;
        ***REMOVED***
    ***REMOVED***
***REMOVED***
***REMOVED***
