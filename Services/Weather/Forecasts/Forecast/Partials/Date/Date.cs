namespace BlazorApp.Services.Weather.Forecasts.Forecast.Partials.Data;

public static class Date
{
    public static DateOnly GetStartDate() =>
        DateOnly.FromDateTime(DateTime.Now);
}
