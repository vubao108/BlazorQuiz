using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Serilog;
using System.IO;

namespace BlazorVNPTQuiz
***REMOVED***
    public class Program
    ***REMOVED***
        public static void Main(string[] args)
        ***REMOVED***
            var configuration = new ConfigurationBuilder()
           .SetBasePath(Directory.GetCurrentDirectory())
           .AddJsonFile("appsettings.json")
              .AddJsonFile($"appsettings.***REMOVED***Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"***REMOVED***.json", true)
           .Build();

            Log.Logger = new LoggerConfiguration()
           .ReadFrom.Configuration(configuration)
           .CreateLogger();
            CreateHostBuilder(args).Build().Run();
    ***REMOVED***

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args).UseSerilog()


                .ConfigureWebHostDefaults(webBuilder =>
                ***REMOVED***

                    webBuilder.UseStartup<Startup>();
            ***REMOVED***);
***REMOVED***
***REMOVED***
