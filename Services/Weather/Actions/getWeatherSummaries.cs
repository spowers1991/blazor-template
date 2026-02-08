namespace BlazorApp.Services.Weather.Actions.WeatherSummaries
{
    public static class WeatherSummaries
    {
        public static string[] GetSummaries() =>
            new[]
            {
                "Freezing", "Bracing", "Chilly", "Cool", "Mild",
                "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
            };
    }
}
