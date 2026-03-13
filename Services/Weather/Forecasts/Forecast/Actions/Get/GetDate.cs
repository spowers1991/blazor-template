namespace BlazorApp.Services.Weather.Forecasts.Forecast.Actions.Get;

public static class GetDate
{
    public static DateOnly Execute() =>
        DateOnly.FromDateTime(DateTime.Now);
}
