using WeatherData = BlazorApp.Services.Weather.Forecasts.Forecast.Models.WeatherData.WeatherData;

namespace BlazorApp.Services.Weather.Forecasts.Actions.Builders
{
    public static class ForecastArrayBuilder
    {
        public static IEnumerable<WeatherData> Build(
            Func<DateOnly> getStartDate,
            Func<string[]> getSummaries,
            Func<DateOnly, int, string[], WeatherData> createForecast,
            int count = 5)
        {
            var startDate = getStartDate();
            var summaries = getSummaries();
            var forecasts = new List<WeatherData>();
            for (int i = 0; i < count; i++)
            {
                forecasts.Add(createForecast(startDate, i, summaries));
            }
            return forecasts;
        }
    }
}
