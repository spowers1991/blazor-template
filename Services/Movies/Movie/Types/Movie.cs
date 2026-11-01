namespace BlazorApp.Services.Movies.Movie.Types;

public class Movie
{
    [System.Text.Json.Serialization.JsonPropertyName("_id")]
    public string? Id { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("title")]
    public string? Title { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("releaseDate")]
    public string? ReleaseDate { get; set; }
}
