using WebApiServiceForBlazor.Models;
using WebApiServiceForBlazor.Models.DTO;

namespace WebApiServiceForBlazor.Services.Interfaces
{
    public interface IWeatherForecastService
    {
        WeatherForecast[] GenerateForecasts();
        //WeatherForecast[] GetFromDb();
        WeatherForecastDTO[] GetFromDb();
        Task Generate();
        //Task Add(WeatherForecast model);
        Task Add(WeatherForecastDTO model);
    }
}
