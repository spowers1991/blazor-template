using BlazorApp.Services.Weather.Forecasts.Forecast.Models.WeatherData;
using BlazorApp.Services.Weather.Forecasts.API;

namespace BlazorApp.Services.Weather.Forecasts;

public class Forecasts
{
    private WeatherData[]? _forecasts;
    
    public WeatherData[] GetForecasts()
    {
        // Cache the data on first call
        if (_forecasts == null)
        {
            _forecasts = WeatherAPI.GetForecasts()?.ToArray();
        
        }
        return _forecasts ?? Array.Empty<WeatherData>();
    }
}