using Microsoft.AspNetCore.Mvc;

namespace BlazorApp.Services.Weather.Forecasts.Forecast;

[ApiController]
[Route("api/[controller]")]
public class Forecast : ControllerBase
{
    [HttpGet]
    public ActionResult<Forecast> GetForecast()
    {
        var forecastData = Actions.Get.GetForecastData.Execute();
        return Ok(forecastData);
    }
}
