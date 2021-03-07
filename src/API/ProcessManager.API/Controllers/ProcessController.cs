
namespace ProcessManager.API.Controllers
{
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("[controller]")]
    public class ProcessController : ControllerBase
    {
        public ProcessController()
        {
            
        }

        [HttpPost]
        public IEnumerable<WeatherForecast> Get()
        {
            var result = new List<WeatherForecast>();
            return result;
        }
    }
}
