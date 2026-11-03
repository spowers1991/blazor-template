namespace BlazorApp.Lib.Filters.Actions.Create;

public static class CreateFilter
{
    public static FilterOption Option(FilterOptionType type, string label, string propertyToSearch) =>
        new() { Type = type, Label = label, PropertyToSearch = propertyToSearch };

    public static FilterRule<T> Rule<T>(string key, string label, Func<T, bool> predicate) =>
        new() { Key = key, Label = label, Predicate = predicate };
}
