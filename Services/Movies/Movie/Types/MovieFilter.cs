namespace BlazorApp.Services.Movies.Movie.Types;

public class MovieFilter
{
    public string Title { get; set; } = string.Empty;
    public bool OnlyRecent { get; set; }
}
