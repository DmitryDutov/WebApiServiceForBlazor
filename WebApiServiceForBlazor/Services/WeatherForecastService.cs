using WebApiServiceForBlazor.DataBase;
using WebApiServiceForBlazor.Models;
using WebApiServiceForBlazor.Services.Interfaces;

namespace WebApiServiceForBlazor.Services
{
    public class WeatherForecastService : IWeatherForecastService
    {
        private static readonly string[] Summaries = new[] { "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching" };
        private readonly WeatherDbContext _context;

        public WeatherForecastService(WeatherDbContext context)
        {
            _context = context;
        }

        public WeatherForecast[] GenerateForecasts()
        {

            return Enumerable
                .Range(1, 5)
                .Select(
                    index =>
                        new WeatherForecast
                        {
                            Date = DateTime.Now.AddDays(index),
                            TemperatureC = Random.Shared.Next(-20, 55),
                            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
                        }
                )
                .ToArray();
        }

        public async Task Generate()
        {
            var tmpModel = new WeatherForecast
            {
                Date = DateTime.Now,
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            };

            await Add(tmpModel); //вызываем метод Add
        }

        public WeatherForecast[] GetFromDb()
        {
            return _context.Forecasts.ToList().ToArray();
        }


        public WeatherForecast[] Get()
        {
            return _context.Forecasts.Select(x => new WeatherForecast()).ToArray();
        }

        public async Task Add(WeatherForecast model)
        {
            await _context.Forecasts.AddAsync(model);
            await _context.SaveChangesAsync();
        }
    }
}
