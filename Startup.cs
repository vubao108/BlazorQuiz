
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorVNPTQuiz.Repository.DataContext;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;
using BlazorVNPTQuiz.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Components.Authorization;
using BlazorVNPTQuiz.Areas.Identity;
using Microsoft.AspNetCore.HttpOverrides;
using BlazorVNPTQuiz.Services;
using Blazored.Modal;
using log4net;
using Microsoft.Extensions.Logging;
using Syncfusion.Blazor;

namespace BlazorVNPTQuiz
***REMOVED***
    public class Startup
    ***REMOVED***
        public Startup(IConfiguration configuration)
        ***REMOVED***
            Configuration = configuration;
    ***REMOVED***

        public IConfiguration Configuration ***REMOVED*** get; ***REMOVED***

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        ***REMOVED***
            string mySqlConnectionStr = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContextPool<ApplicationDbContext>(options =>
                options.UseMySql(mySqlConnectionStr, ServerVersion.AutoDetect(mySqlConnectionStr)));

            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

           
            services.AddRazorPages();
            services.Configure<ForwardedHeadersOptions>(options =>
            ***REMOVED***
                options.ForwardedHeaders =
                    ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
        ***REMOVED***);
            services.AddServerSideBlazor();
            // services.AddSyncfusionBlazor(options => ***REMOVED*** options.IgnoreScriptIsolation = true; ***REMOVED***);
            services.AddSyncfusionBlazor();
            services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<IdentityUser>>();
           
           
           
            
            
            services.AddScoped<IRepositoryExam, MySqlRepositoryExam>();
            services.AddScoped<IRepositoryOntap, MySqlRepositoryOntap>();
            services.AddScoped<AppState>();
            services.AddBlazoredModal();
            services.AddHttpClient();


    ***REMOVED***

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        ***REMOVED***
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NTgxNTUyQDMxMzkyZTM0MmUzMG0rakNONTBmUXJPQXR3c29rUWhEWmg5UkdPaEVzU01GSkx5ZUtrZmxiSUE9");
            //var loggingOptions = this.Configuration.GetSection("Log4NetCore")
            //                                   .Get<Log4NetProviderOptions>();
            //loggerFactory.AddLog4Net("Log.config");
            if (env.IsDevelopment())
            ***REMOVED***
                app.UseDeveloperExceptionPage();
                //app.UseForwardedHeaders();
        ***REMOVED***
            else
            ***REMOVED***
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                //app.UseForwardedHeaders();
               // app.UseHsts();
        ***REMOVED***
            app.UseForwardedHeaders(new ForwardedHeadersOptions
            ***REMOVED***
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
        ***REMOVED***);
            // app.UseHttpsRedirection();
            app.UsePathBase("/quiz");
            app.UseStaticFiles();
           
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            ***REMOVED***
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
        ***REMOVED***);
    ***REMOVED***
***REMOVED***
***REMOVED***
