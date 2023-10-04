using Microsoft.EntityFrameworkCore;
using WebApiServiceForBlazor.Models;

namespace WebApiServiceForBlazor.DataBase
{
    public class WeatherDbContext : DbContext
    {
        public DbSet<WeatherForecast> Forecasts { get; set; }

        public WeatherDbContext(DbContextOptions<WeatherDbContext> options): base(options)
        {
            Database.EnsureCreated();
        }
    }
}

