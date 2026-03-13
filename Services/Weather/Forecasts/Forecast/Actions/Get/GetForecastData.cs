using BlazorApp.Services.Weather.Forecasts.Forecast.Types;

namespace BlazorApp.Services.Weather.Forecasts.Forecast.Actions.Get

{
    public static class GetForecastData
    {
        public static Types.Forecast Execute()
        {
            var date = GetDate.Execute();
            var summaries = GetSummaries.Execute();
            var rng = new Random();
            return new Types.Forecast(
                date,
                rng.Next(-20, 55),
                summaries[rng.Next(summaries.Length)]
            );
        }
    }
}