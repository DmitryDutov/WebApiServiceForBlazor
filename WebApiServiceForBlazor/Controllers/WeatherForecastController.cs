using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using WebApiServiceForBlazor.Models;
using WebApiServiceForBlazor.Models.DTO;
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
        {
            // ����� �������
            var generateCollection = _weatherForecastService.GenerateForecasts();
            return generateCollection;
        }

        [HttpPost]
        public async Task<IActionResult> Post(WeatherForecastDTO model)
        {
            if (!ModelState.IsValid )
            {
                return StatusCode(401, "Weather model is incorrect!");
            }

            try
            {
                await _weatherForecastService.Add(model);   // ������ �� �� ���������� ��������� ��������, � ��������� � ������� + ��������� � ��
                return StatusCode(200, _weatherForecastService.GetFromDb()); // ���� ��������� ������, �� ������� ������ �� ��
            }
            catch (Exception)
            {
                return StatusCode(500, "Code generate Error");
            }

        }
    }
}
