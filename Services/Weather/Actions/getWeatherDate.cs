namespace BlazorApp.Services.Weather.Actions.WeatherForeCastDate
{
    public static class WeatherForeCastDate
    {
        public static DateOnly GetStartDate() =>
            DateOnly.FromDateTime(DateTime.Now);
    }
}
