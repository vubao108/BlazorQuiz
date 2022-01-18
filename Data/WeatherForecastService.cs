using System;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorVNPTQuiz.Data
***REMOVED***
    public class WeatherForecastService
    ***REMOVED***
        private static readonly string[] Summaries = new[]
        ***REMOVED***
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    ***REMOVED***;

        public Task<WeatherForecast[]> GetForecastAsync(DateTime startDate)
        ***REMOVED***
            var rng = new Random();
            return Task.FromResult(Enumerable.Range(1, 5).Select(index => new WeatherForecast
            ***REMOVED***
                Date = startDate.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
        ***REMOVED***).ToArray());
    ***REMOVED***
***REMOVED***
***REMOVED***
