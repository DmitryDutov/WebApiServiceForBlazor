using WebApiServiceForBlazor.Models;

namespace WebApiServiceForBlazor.Services.Interfaces
{
    public interface IWeatherForecastService
    {
        WeatherForecast[] GenerateForecasts();
        WeatherForecast[] GetFromDb();
        Task Generate();
        Task Add(WeatherForecast model);
    }
}
