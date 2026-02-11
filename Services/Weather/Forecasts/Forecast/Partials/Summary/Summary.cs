namespace BlazorApp.Services.Weather.Forecasts.Forecast.Partials.Summaries;

public static class Summaries
{
    public static string[] GetSummaries() =>
        new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild",
            "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };
}
