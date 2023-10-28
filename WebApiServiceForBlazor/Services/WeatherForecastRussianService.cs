using WebApiServiceForBlazor.DataBase;
using WebApiServiceForBlazor.Models;
using WebApiServiceForBlazor.Models.DTO;
using WebApiServiceForBlazor.Services.Interfaces;

namespace WebApiServiceForBlazor.Services
{
    public class WeatherForecastRussianService : IWeatherForecastService
    {
        private static readonly string[] Summaries = new[] { "Мерзлота", "Холодрыга", "Прохладно", "Нормуль", "Пойдёт", "Тепло", "Ничё так", "Горячо", "Потно", "Жарень" };
        private readonly WeatherDbContext _context;

        public WeatherForecastRussianService(WeatherDbContext context)
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
            var tmpModel = new WeatherForecastDTO
            {
                Date = DateTime.Now,
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            };

            await Add(tmpModel); //вызываем метод Add
        }

        public WeatherForecastDTO[] GetFromDb()
        {
            return _context.Forecasts.Select(x => new WeatherForecastDTO
            {
                Date = x.Date,
                TemperatureC = x.TemperatureC,
                Summary = x.Summary
            }).ToArray();
        }


        public WeatherForecastDTO[] Get()
        {
            return _context.Forecasts.Select(x => new WeatherForecastDTO()).ToArray();
        }

        public async Task Add(WeatherForecastDTO model)
        {
            await _context.Forecasts.AddAsync(new WeatherForecast
            {
                Date = model.Date,
                TemperatureC = model.TemperatureC,
                Summary = model.Summary,
            });

            await _context.SaveChangesAsync();
        }

    }
}
