using BlazorApp.Lib.Sanity.Clients;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace BlazorApp.Services.Movies;

[ApiController]
[Route("api/[controller]")]
public class Movies : ControllerBase
{
    private readonly SanityClient _sanity;

    public Movies(SanityClient sanity) => _sanity = sanity;

    [HttpGet("all")]
    public async Task<ActionResult<Movie.Types.Movie[]>> GetAll()
    {
        var json = await _sanity.QueryAsync("*[_type == \"movie\"]");
        using var doc = JsonDocument.Parse(json);
        if (!doc.RootElement.TryGetProperty("result", out var result))
        {
            return StatusCode(502, json);
        }
        return Ok(result.Deserialize<Movie.Types.Movie[]>() ?? Array.Empty<Movie.Types.Movie>());
    }
}
