namespace BlazorApp.Services.Weather.Forecasts.Actions.Builders
{
    public static class ForecastArrayBuilder
    {
        public static IEnumerable<Forecast.Types.Forecast> Build(
            Func<Forecast.Types.Forecast> forecast)
        {
            var forecasts = new List<Forecast.Types.Forecast>();

            for (int i = 0; i < 5; i++)
            {
                forecasts.Add(forecast());
            }

            return forecasts;
        }
    }
}
