using BlazorApp.Lib.Filters.Actions.Get;

namespace BlazorApp.Lib.Filters.Actions.Run;

public static class RunFilter
{
    public static IEnumerable<T> Execute<T>(
        IEnumerable<T> items,
        IReadOnlyList<FilterOption> options,
        IReadOnlyDictionary<string, string[]> values,
        IReadOnlyList<FilterRule<T>> rules,
        IReadOnlySet<string> activeRules) =>
        items.Where(item =>
            rules.Where(r => activeRules.Contains(r.Key)).All(r => r.Predicate(item))
            && values.All(entry => Matches(item, entry.Key, entry.Value, options)));

    private static bool Matches<T>(T item, string propertyPath, string[] selected, IReadOnlyList<FilterOption> options)
    {
        if (selected.Length == 0)
        {
            return true;
        }

        var type = options.FirstOrDefault(o => o.PropertyToSearch == propertyPath)?.Type ?? FilterOptionType.Checkbox;
        var itemValues = GetFilter.PropertyValues(item, propertyPath).ToList();

        return type == FilterOptionType.TextSearch
            ? itemValues.Any(v => v.Contains(selected[0], StringComparison.OrdinalIgnoreCase))
            : selected.All(itemValues.Contains);
    }
}
