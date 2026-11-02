namespace BlazorApp.Lib.Filters;

public class FilterRule<T>
{
    public string Key { get; init; } = string.Empty;

    public string Label { get; init; } = string.Empty;

    public Func<T, bool> Predicate { get; init; } = _ => true;
}
