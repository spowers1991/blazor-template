using System.Text.Json;
using System.Text.Json.Serialization;

namespace BlazorApp.Services.Movies.Movie.Types;

public class Movie
{
    [JsonPropertyName("_id")]
    public string? Id { get; set; }

    [JsonPropertyName("_type")]
    public string? Type { get; set; }

    [JsonPropertyName("_rev")]
    public string? Rev { get; set; }

    [JsonPropertyName("_createdAt")]
    public string? CreatedAt { get; set; }

    [JsonPropertyName("_updatedAt")]
    public string? UpdatedAt { get; set; }

    [JsonPropertyName("externalId")]
    public int? ExternalId { get; set; }

    [JsonPropertyName("title")]
    public string? Title { get; set; }

    [JsonPropertyName("slug")]
    public Slug? Slug { get; set; }

    [JsonPropertyName("releaseDate")]
    public string? ReleaseDate { get; set; }

    [JsonPropertyName("popularity")]
    public double? Popularity { get; set; }

    [JsonPropertyName("overview")]
    public List<PortableTextBlock>? Overview { get; set; }

    [JsonPropertyName("poster")]
    public Poster? Poster { get; set; }

    [JsonPropertyName("castMembers")]
    public List<CastMember>? CastMembers { get; set; }

    [JsonPropertyName("crewMembers")]
    public List<CrewMember>? CrewMembers { get; set; }

    public bool IsReleasedSince(int year) =>
        DateTime.TryParse(ReleaseDate, out var date) && date.Year >= year;
}

public class Slug
{
    [JsonPropertyName("_type")]
    public string? Type { get; set; }

    [JsonPropertyName("current")]
    public string? Current { get; set; }

    [JsonPropertyName("source")]
    public string? Source { get; set; }
}

public class Reference
{
    [JsonPropertyName("_type")]
    public string? Type { get; set; }

    [JsonPropertyName("_ref")]
    public string? Ref { get; set; }
}

public class PortableTextBlock
{
    [JsonPropertyName("_key")]
    public string? Key { get; set; }

    [JsonPropertyName("_type")]
    public string? Type { get; set; }

    [JsonPropertyName("style")]
    public string? Style { get; set; }

    [JsonPropertyName("markDefs")]
    public List<JsonElement>? MarkDefs { get; set; }

    [JsonPropertyName("children")]
    public List<PortableTextSpan>? Children { get; set; }
}

public class PortableTextSpan
{
    [JsonPropertyName("_key")]
    public string? Key { get; set; }

    [JsonPropertyName("_type")]
    public string? Type { get; set; }

    [JsonPropertyName("text")]
    public string? Text { get; set; }

    [JsonPropertyName("marks")]
    public List<string>? Marks { get; set; }
}

public class Poster
{
    [JsonPropertyName("_type")]
    public string? Type { get; set; }

    [JsonPropertyName("asset")]
    public Reference? Asset { get; set; }

    [JsonPropertyName("crop")]
    public ImageCrop? Crop { get; set; }

    [JsonPropertyName("hotspot")]
    public ImageHotspot? Hotspot { get; set; }
}

public class ImageCrop
{
    [JsonPropertyName("top")]
    public double Top { get; set; }

    [JsonPropertyName("bottom")]
    public double Bottom { get; set; }

    [JsonPropertyName("left")]
    public double Left { get; set; }

    [JsonPropertyName("right")]
    public double Right { get; set; }
}

public class ImageHotspot
{
    [JsonPropertyName("x")]
    public double X { get; set; }

    [JsonPropertyName("y")]
    public double Y { get; set; }

    [JsonPropertyName("width")]
    public double Width { get; set; }

    [JsonPropertyName("height")]
    public double Height { get; set; }
}

public class CastMember
{
    [JsonPropertyName("_key")]
    public string? Key { get; set; }

    [JsonPropertyName("_type")]
    public string? Type { get; set; }

    [JsonPropertyName("characterName")]
    public string? CharacterName { get; set; }

    [JsonPropertyName("externalCreditId")]
    public string? ExternalCreditId { get; set; }

    [JsonPropertyName("externalId")]
    public int? ExternalId { get; set; }

    [JsonPropertyName("person")]
    public Reference? Person { get; set; }
}

public class CrewMember
{
    [JsonPropertyName("_key")]
    public string? Key { get; set; }

    [JsonPropertyName("_type")]
    public string? Type { get; set; }

    [JsonPropertyName("department")]
    public string? Department { get; set; }

    [JsonPropertyName("job")]
    public string? Job { get; set; }

    [JsonPropertyName("externalCreditId")]
    public string? ExternalCreditId { get; set; }

    [JsonPropertyName("externalId")]
    public int? ExternalId { get; set; }

    [JsonPropertyName("person")]
    public Reference? Person { get; set; }
}
