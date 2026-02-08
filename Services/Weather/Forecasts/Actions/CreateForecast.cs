using WeatherForecastModel = BlazorApp.Services.Weather.Models.WeatherData;

namespace BlazorApp.Services.Weather.Forecasts.Actions.CreateForecast;

public static class CreateForecast
{
    public static WeatherForecastModel AddForecast(
        DateOnly startDate,
        int index,
        string[] summaries)
    {
        return new WeatherForecastModel
        {
            Date = startDate.AddDays(index),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = summaries[Random.Shared.Next(summaries.Length)]
        };
    }
}
