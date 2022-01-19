using System;
using BlazorVNPTQuiz.Repository.DataContext;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(BlazorVNPTQuiz.Areas.Identity.IdentityHostingStartup))]
namespace BlazorVNPTQuiz.Areas.Identity
***REMOVED***
    public class IdentityHostingStartup : IHostingStartup
    ***REMOVED***
        public void Configure(IWebHostBuilder builder)
        ***REMOVED***
            builder.ConfigureServices((context, services) => ***REMOVED***
        ***REMOVED***);
    ***REMOVED***
***REMOVED***
***REMOVED***