namespace BlazorApp.Lib.Filters.Actions.Set;

public static class SetFilter
{
    // An empty selection removes the filter for that property.
    public static void Values(IDictionary<string, string[]> values, string propertyPath, string[] selectedOptions)
    {
        var selected = selectedOptions
            .Where(o => !string.IsNullOrWhiteSpace(o))
            .Select(o => o.Trim())
            .ToArray();

        if (selected.Length == 0)
        {
            values.Remove(propertyPath);
        }
        else
        {
            values[propertyPath] = selected;
        }
    }

    public static void Rule(ISet<string> activeRules, string key, bool enabled)
    {
        if (enabled)
        {
            activeRules.Add(key);
        }
        else
        {
            activeRules.Remove(key);
        }
    }
}
