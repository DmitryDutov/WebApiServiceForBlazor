using Microsoft.AspNetCore.Mvc;
using WebApiServiceForBlazor.Models;
using WebApiServiceForBlazor.Services;
using WebApiServiceForBlazor.Services.Interfaces;

namespace WebApiServiceForBlazor.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IWeatherForecastService _weatherForecastService;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IWeatherForecastService weather)
        {
            _logger = logger;
            _weatherForecastService = weather;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            // Âûחמג סונגטסא
            return _weatherForecastService.GenerateForecasts();
        }
    }
}
