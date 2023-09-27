using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using WebApiServiceForBlazor.Models;
using WebApiServiceForBlazor.Services;
using WebApiServiceForBlazor.Services.Interfaces;

namespace WebApiServiceForBlazor.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IWeatherForecastService _weatherForecastService;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IWeatherForecastService weather)
        {
            _logger = logger;
            _weatherForecastService = weather;
        }

        [HttpGet(Name = "Get")]
        //[Route("GetWeather")]
        public IEnumerable<WeatherForecast> Get()
        //public IActionResult Get()
        //public JsonResult Get()
        {
            // Âûחמג סונגטסא
            var generateCollection = _weatherForecastService.GenerateForecasts();
            return generateCollection;

            //string json = JsonSerializer.Serialize(generateCollection);
            //JsonResult jsonResult = new JsonResult(json);
            //return jsonResult;
        }
    }
}
