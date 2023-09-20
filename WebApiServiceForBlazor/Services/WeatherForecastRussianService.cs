using WebApiServiceForBlazor.Models;
using WebApiServiceForBlazor.Services.Interfaces;

namespace WebApiServiceForBlazor.Services
{
    public class WeatherForecastRussianService : IWeatherForecastService
    {
        private static readonly string[] Summaries = new[]
        {
            "Мерзлота", "Холодрыга", "Прохладно", "Нормуль", "Пойдёт", "Тепло", "Ничё так", "Горячо", "Потно", "Жарень"
        };

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

    }
}
