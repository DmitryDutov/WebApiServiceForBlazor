using Microsoft.EntityFrameworkCore;
using WebApiServiceForBlazor.DataBase;
using WebApiServiceForBlazor.Services;
using WebApiServiceForBlazor.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//DB
var connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<WeatherDbContext>(options => options.UseSqlServer(connection));

//Service
builder.Services.AddScoped<IWeatherForecastService, WeatherForecastRussianService>();    // Ёкземпл€р сервиса создаЄтс€ при обращении к сервису и живЄт до окончани€ выполнени€ задчи
//builder.Services.AddTransient<IWeatherForecastService, WeatherForecastService>(); // Ёкземпл€р сервиса создаЄтс€ при каждом обращении к сервису даже если это происходит одновременно. Ёкземпл€р живЄт до окончани€ выполнени€ задачи
//builder.Services.AddSingleton<IWeatherForecastService, WeatherForecastService>(); // Ёкземпл€р сервиса создаЄтс€ при запуске приложени€ и живЄт до окончани€ работы приложени€

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
