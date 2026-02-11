using BlazorApp.Services.Weather.Forecasts.Forecast.Models.WeatherData;

namespace BlazorApp.Services.Weather.Forecasts.API
{
    public static class WeatherAPI
    {
    public static IEnumerable<WeatherData> GetForecasts()
        {
            System.Diagnostics.Debug.WriteLine("GetForecasts called");
            var forecasts = new List<WeatherData>();
            var startDate = DateOnly.FromDateTime(DateTime.Now);
            var summaries = new[] { "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching" };
            for (int i = 0; i < 5; i++)
            {
                forecasts.Add(new WeatherData(
                    startDate.AddDays(i),
                    20 + i,
                    summaries[i % summaries.Length]
                ));
            }
            System.Diagnostics.Debug.WriteLine($"GetForecasts returning {forecasts.Count} forecasts");
            return forecasts;
        }
    }
}
