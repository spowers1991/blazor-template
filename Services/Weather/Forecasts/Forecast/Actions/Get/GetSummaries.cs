namespace BlazorApp.Services.Weather.Forecasts.Forecast.Actions.Get
{
    public static class GetSummaries
    {
        public static string[] Execute()
        {
            return new[]
            {
                "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
            };
        }
    }
}