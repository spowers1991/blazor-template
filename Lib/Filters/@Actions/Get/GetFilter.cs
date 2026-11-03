using System.Collections;
using System.Reflection;

namespace BlazorApp.Lib.Filters.Actions.Get;

public static class GetFilter
{
    public static bool IsActive(IReadOnlyDictionary<string, string[]> values, IReadOnlySet<string> activeRules) =>
        values.Count > 0 || activeRules.Count > 0;

    public static IEnumerable<string> PropertyValues(object? item, string propertyPath) =>
        Resolve(item, propertyPath.Split('.'), 0).Select(v => v as string ?? v.ToString() ?? string.Empty);

    // Walks a dotted path, flattening any collections met along the way.
    private static IEnumerable<object> Resolve(object? source, string[] parts, int index)
    {
        if (source is null)
        {
            yield break;
        }

        var property = source.GetType().GetProperty(
            parts[index], BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase);
        var value = property?.GetValue(source);
        if (value is null)
        {
            yield break;
        }

        var candidates = value is IEnumerable sequence and not string
            ? sequence.Cast<object?>()
            : new[] { value };

        foreach (var candidate in candidates)
        {
            if (candidate is null)
            {
                continue;
            }

            if (index == parts.Length - 1)
            {
                yield return candidate;
                continue;
            }

            foreach (var nested in Resolve(candidate, parts, index + 1))
            {
                yield return nested;
            }
        }
    }
}
