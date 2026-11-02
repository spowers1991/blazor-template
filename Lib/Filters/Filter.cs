namespace BlazorApp.Lib.Filters;

public static class Filter
{
    public static IEnumerable<T> Execute<T>(IEnumerable<T> items, FilterConfig<T> config)
    {
        var text = config.Text.Trim();

        if (text.Length > 0 && config.TextSelector is { } selector)
        {
            items = items.Where(i => selector(i)?.Contains(text, StringComparison.OrdinalIgnoreCase) == true);
        }

        foreach (var predicate in config.Predicates)
        {
            items = items.Where(predicate);
        }

        return items;
    }
}
