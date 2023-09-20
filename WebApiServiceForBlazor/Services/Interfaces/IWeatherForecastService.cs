using WebApiServiceForBlazor.Models;

namespace WebApiServiceForBlazor.Services.Interfaces
{
    public interface IWeatherForecastService
    {
        WeatherForecast[] GenerateForecasts();
    }
}
