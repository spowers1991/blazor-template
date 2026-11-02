using BlazorApp.Lib.Filters.Actions.Get;
using BlazorApp.Lib.Filters.Actions.Run;
using BlazorApp.Lib.Filters.Actions.Set;

namespace BlazorApp.Lib.Filters;

public class Filter<T>
{
    private readonly Dictionary<string, string[]> values = new();
    private readonly HashSet<string> activeRules = new();
    private IReadOnlyList<T>? filteredItems;

    public IReadOnlyList<T> Items { get; private set; } = [];

    public IReadOnlyList<FilterOption> Options { get; private set; } = [];

    public IReadOnlyList<FilterRule<T>> Rules { get; private set; } = [];

    public IReadOnlyDictionary<string, string[]> Values => values;

    public IReadOnlySet<string> ActiveRules => activeRules;

    public bool IsActive => GetFilter.IsActive(values, activeRules);

    public IReadOnlyList<T> Run() =>
        filteredItems ??= RunFilter.Execute(Items, Options, values, Rules, activeRules).ToList();

    public Filter<T> Setup(
        IEnumerable<T> itemsToFilter,
        IEnumerable<FilterOption> filterOptions,
        IEnumerable<FilterRule<T>>? filterRules = null) =>
        SetItems(itemsToFilter).SetOptions(filterOptions).SetRules(filterRules ?? []);

    public Filter<T> SetItems(IEnumerable<T> itemsToFilter)
    {
        Items = itemsToFilter.ToList();
        filteredItems = null;
        return this;
    }

    public Filter<T> SetOptions(IEnumerable<FilterOption> filterOptions)
    {
        Options = filterOptions.ToList();
        filteredItems = null;
        return this;
    }

    public Filter<T> SetRules(IEnumerable<FilterRule<T>> filterRules)
    {
        Rules = filterRules.ToList();
        activeRules.IntersectWith(Rules.Select(r => r.Key));
        filteredItems = null;
        return this;
    }

    public Filter<T> SetValues(IReadOnlyDictionary<string, string[]> filterValues)
    {
        values.Clear();
        foreach (var (propertyPath, selectedOptions) in filterValues)
        {
            SetFilter.Values(values, propertyPath, selectedOptions);
        }
        filteredItems = null;
        return this;
    }

    public Filter<T> SetValue(string propertyPath, params string[] selectedOptions)
    {
        SetFilter.Values(values, propertyPath, selectedOptions);
        filteredItems = null;
        return this;
    }

    public Filter<T> SetRuleActive(string key, bool enabled = true)
    {
        SetFilter.Rule(activeRules, key, enabled);
        filteredItems = null;
        return this;
    }

    public Filter<T> ClearValues()
    {
        values.Clear();
        activeRules.Clear();
        filteredItems = null;
        return this;
    }
}
