using System;
using System.Collections.Generic;
using WeatherForecastModel = BlazorApp.Services.Weather.Models.WeatherData;

namespace BlazorApp.Services.Weather.Forecasts.Actions.ForecastArrayBuilder
{
    public static class ForecastArrayBuilder
    {
        public static IEnumerable<WeatherForecastModel> Build(
            Func<DateOnly> getStartDate,
            Func<string[]> getSummaries,
            Func<DateOnly, int, string[], WeatherForecastModel> createForecast,
            int count = 5)
        {
            var startDate = getStartDate();
            var summaries = getSummaries();
            var forecasts = new List<WeatherForecastModel>();
            for (int i = 0; i < count; i++)
            {
                forecasts.Add(createForecast(startDate, i, summaries));
            }
            return forecasts;
        }
    }
}
