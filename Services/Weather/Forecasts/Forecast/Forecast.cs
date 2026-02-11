using BlazorApp.Services.Weather.Forecasts.Forecast.Models.WeatherData;

namespace BlazorApp.Services.Weather.Forecasts.Forecast;

public class Forecast
{
    public static WeatherData Create(
        DateOnly startDate,
        int index,
        string[] summaries)
    {
        return new WeatherData(
            startDate.AddDays(index),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        );
    }
}
