using BlazorApp.Services.Weather.Forecasts.Forecast.Models.WeatherData;
using BlazorApp.Services.Weather.Forecasts.API;

namespace BlazorApp.Services.Weather.Forecasts;

public class Forecasts
{
    public static IEnumerable<WeatherData> GetForecasts()
    {
        return WeatherAPI.GetForecasts();
    }
    
}