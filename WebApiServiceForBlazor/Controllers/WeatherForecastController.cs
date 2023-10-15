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

        [HttpGet(Name = "GenerateWithoutDB")]
        //[Route("GetWeather")]
        public IEnumerable<WeatherForecast> GenerateWithoutDB()
        //public IActionResult Get()0
        //public JsonResult Get()
        {
            // ����� �������
            var generateCollection = _weatherForecastService.GenerateForecasts();
            return generateCollection;

            //string json = JsonSerializer.Serialize(generateCollection);
            //JsonResult jsonResult = new JsonResult(json);
            //return jsonResult;
        }

        //[HttpGet(Name = "GenerateWithoutDB")]
        [HttpPost]
        public async Task<IEnumerable<WeatherForecast>> Generate()
        {
            await _weatherForecastService.Generate();      // ���������� ����� ������ � ���������� � ��
            return _weatherForecastService.GetFromDb(); // ������� ������ �� ��
        }
    }
}
