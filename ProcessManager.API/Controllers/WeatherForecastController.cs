namespace ProcessManager.API.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Dummy;
    using Logger;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger logger;
        private readonly IDummy dummy;

        public WeatherForecastController(ILogger logger, IDummy dummy)
        {
            this.logger = logger;
            this.dummy = dummy;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            this.logger.Error($"Called {nameof(WeatherForecastController)}.Get()");
            var rng = new Random();
            var weatherForecasts = Enumerable.Range(1, 5).Select(index => new WeatherForecast
                {
                    Date = DateTime.Now.AddDays(index),
                    TemperatureC = rng.Next(-20, 55),
                    Summary = Summaries[rng.Next(Summaries.Length)]
                })
                .ToList();
            weatherForecasts.Insert(0, new WeatherForecast
            {
                Date = DateTime.Now.AddDays(1),
                Summary = this.dummy.Call(),
                TemperatureC = 20
            });
            return weatherForecasts;
        }
    }
}
