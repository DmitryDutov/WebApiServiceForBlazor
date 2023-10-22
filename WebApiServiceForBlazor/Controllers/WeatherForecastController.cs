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
            // Вызов сервиса
            var generateCollection = _weatherForecastService.GenerateForecasts();
            return generateCollection;
        }

        ////[HttpGet(Name = "GenerateWithoutDB")]
        //[HttpPost]
        ////public async Task<IEnumerable<WeatherForecast>> Generate()
        //public async Task<IEnumerable<WeatherForecastDTO>> Generate()
        //{
        //    await _weatherForecastService.Generate();      // генерируем новые данные и отправляем в БД
        //    return _weatherForecastService.GetFromDb(); // выводим данные из БД
        //}

        //[HttpPost]
        //public async Task<IEnumerable<WeatherForecastDTO>> Post(WeatherForecastDTO model)
        //{
        //    await _weatherForecastService.Add(model);   // теперь мы не генерируем случайные значения, а принимаем с клиента + сохраняем в БД
        //    return _weatherForecastService.GetFromDb(); // выводим данные из БД
        //}

        [HttpPost]
        public async Task<IActionResult> Post(WeatherForecastDTO model)
        {
            if (!ModelState.IsValid )
            {
                return StatusCode(401, "Weather model is incorrect!");
            }

            try
            {
                await _weatherForecastService.Add(model);   // теперь мы не генерируем случайные значения, а принимаем с клиента + сохраняем в БД
                return StatusCode(200, _weatherForecastService.GetFromDb()); // если валидация прошла, то выводим данные из БД
            }
            catch (Exception)
            {
                return StatusCode(500, "Code generate Error");
            }

        }
    }
}
