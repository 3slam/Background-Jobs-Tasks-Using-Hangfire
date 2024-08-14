using Hangfire;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System.Text.RegularExpressions;

namespace Background_Jobs__Tasks__Using_Hangfire.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
       

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }



        [HttpGet(Name = "StartbackGroundJobwithHangfire")]
        public IActionResult StartbackGroundJobwithHangfire()
        {
            //RecurringJob.AddOrUpdate(() => SendMessage("Eager to dive into the world of AI/ML but don’t know where to begin?"), Cron.Minutely);
            //BackgroundJob.Schedule(() => SendMessage("Eager to dive into the world of AI/ML but don’t know where to begin?"), TimeSpan.FromMinutes(1));
            BackgroundJob.Enqueue(() => SendMessage("Eager to dive into the world of AI/ML but don’t know where to begin?"));
            return Ok();
        }



        [ApiExplorerSettings(IgnoreApi = true)]
        public void SendMessage(string Message)
        {
           try
            {
                for (int i = 0; i < 5; i++)
                {
                    Log.Information($"No - {i} Message sent at {DateTime.Now} , {Message}");
                }
                throw new Exception("HJbasj");
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
            }

        }
    }
}
