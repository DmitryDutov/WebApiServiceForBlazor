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

        ////[HttpGet(Name = "GenerateWithoutDB")]
        //[HttpPost]
        ////public async Task<IEnumerable<WeatherForecast>> Generate()
        //public async Task<IEnumerable<WeatherForecastDTO>> Generate()
        //{
        //    await _weatherForecastService.Generate();      // ���������� ����� ������ � ���������� � ��
        //    return _weatherForecastService.GetFromDb(); // ������� ������ �� ��
        //}

        [HttpPost]
        public async Task<IEnumerable<WeatherForecastDTO>> Post(WeatherForecastDTO model)
        {
            await _weatherForecastService.Add(model);   // ������ �� �� ���������� ��������� ��������, � ��������� � ������� + ��������� � ��
            return _weatherForecastService.GetFromDb(); // ������� ������ �� ��
        }
    }
}
