using BlazorApp.Services.Weather.Forecasts.Forecast.Types;

namespace BlazorApp.Services.Weather.Forecasts.Actions.Get;

public static class GetForecasts
{
    public static BlazorApp.Services.Weather.Forecasts.Forecast.Types.Forecast[] Execute()
    {
        // Example: return an array with a single dummy forecast
        return new[]
        {
            new BlazorApp.Services.Weather.Forecasts.Forecast.Types.Forecast(DateOnly.FromDateTime(DateTime.Now), 25, "Sunny"),
            new BlazorApp.Services.Weather.Forecasts.Forecast.Types.Forecast(DateOnly.FromDateTime(DateTime.Now), 27, "Sunny"),
            new BlazorApp.Services.Weather.Forecasts.Forecast.Types.Forecast(DateOnly.FromDateTime(DateTime.Now), 23, "Sunny"),
            new BlazorApp.Services.Weather.Forecasts.Forecast.Types.Forecast(DateOnly.FromDateTime(DateTime.Now), 29, "Wet"),
        };
    }
}

