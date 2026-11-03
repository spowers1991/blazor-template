namespace BlazorApp.Lib.Filters;

public class FilterOption
{
    public FilterOptionType Type { get; init; }

    public string Label { get; init; } = string.Empty;

    // Dot-separated path to the property to filter on, e.g. "Slug.Current"
    public string PropertyToSearch { get; init; } = string.Empty;
}
