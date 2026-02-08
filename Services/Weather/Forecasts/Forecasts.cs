using WeatherForecastModel = BlazorApp.Services.Weather.Models.WeatherData;
using BlazorApp.Services.Weather.Forecasts.Actions.ForecastArrayBuilder;
using BlazorApp.Services.Weather.Forecasts.Actions.CreateForecast;
using BlazorApp.Services.Weather.Actions.WeatherForeCastDate;
using BlazorApp.Services.Weather.Actions.WeatherSummaries;

namespace BlazorApp.Services.Weather.Forecasts;

public class Forecasts
{
    public IEnumerable<WeatherForecastModel> GetForecasts()
    {
        System.Diagnostics.Debug.WriteLine("GetForecasts called");
        var result = GetAllForecasts();
        System.Diagnostics.Debug.WriteLine($"GetForecasts returning {result.Count()} forecasts");
        return result;
    }

    public IEnumerable<WeatherForecastModel> GetAllForecasts()
    {
        System.Diagnostics.Debug.WriteLine("GetAllForecasts called");

        var forecasts = ForecastArrayBuilder.Build(
            WeatherForeCastDate.GetStartDate,          // ✅ correct
            WeatherSummaries.GetSummaries,         // ✅ correct
            CreateForecast.AddForecast, // ✅ assuming this is static
            5
        ).ToList();

        foreach (var forecast in forecasts)
        {
            System.Diagnostics.Debug.WriteLine(
                $"Date: {forecast.Date}, TempC: {forecast.TemperatureC}, Summary: {forecast.Summary}"
            );
        }

        System.Diagnostics.Debug.WriteLine($"GetAllForecasts returning {forecasts.Count} forecasts");
        return forecasts;
    }
}
