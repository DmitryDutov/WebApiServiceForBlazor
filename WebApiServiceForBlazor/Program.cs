using WebApiServiceForBlazor.Services;
using WebApiServiceForBlazor.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IWeatherForecastService, WeatherForecastRussianService>();    // ��������� ������� �������� ��� ��������� � ������� � ���� �� ��������� ���������� �����
//builder.Services.AddTransient<IWeatherForecastService, WeatherForecastService>(); // ��������� ������� �������� ��� ������ ��������� � ������� ���� ���� ��� ���������� ������������. ��������� ���� �� ��������� ���������� ������
//builder.Services.AddSingleton<IWeatherForecastService, WeatherForecastService>(); // ��������� ������� �������� ��� ������� ���������� � ���� �� ��������� ������ ����������

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