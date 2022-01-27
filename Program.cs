using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorVNPTQuiz
***REMOVED***
    public class Program
    ***REMOVED***
        public static void Main(string[] args)
        ***REMOVED***
            CreateHostBuilder(args).Build().Run();
    ***REMOVED***

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
             .ConfigureLogging(logging =>
             ***REMOVED***
                 logging.ClearProviders();
                 logging.AddConsole();
                 
         ***REMOVED***)
                .ConfigureWebHostDefaults(webBuilder =>
                ***REMOVED***
                   
                    webBuilder.UseStartup<Startup>();
            ***REMOVED***);
***REMOVED***
***REMOVED***
