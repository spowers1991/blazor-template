using Microsoft.AspNetCore.Mvc;

namespace BlazorApp.Services.Weather.Forecasts;     

[ApiController]
[Route("api/[controller]")]
public class Forecasts : ControllerBase
{
    public static Forecast.Types.Forecast[]? _forecasts;

    [HttpGet]
    public ActionResult<Forecast.Types.Forecast[]> GetAll()
    {
        // Cache the data on first call
        if (_forecasts == null)
        {
            _forecasts = Actions.Get.GetForecasts.Execute();
        }
        return Ok(_forecasts ?? Array.Empty<Forecast.Types.Forecast>());
    }

    [HttpGet("log")]
    public IActionResult LogForecasts()
    {
        foreach (var forecast in _forecasts)
        {
            System.Diagnostics.Debug.WriteLine($"Date: {forecast.Date}, TemperatureC: {forecast.TemperatureC}, Summary: {forecast.Summary}");
        }
        return Ok();

    }
}