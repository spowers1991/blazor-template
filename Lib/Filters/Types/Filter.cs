namespace BlazorApp.Lib.Filters;

public class FilterConfig<T>
{
    public string Text { get; set; } = string.Empty;

    public Func<T, string?>? TextSelector { get; set; }

    public List<Func<T, bool>> Predicates { get; } = new();
}
