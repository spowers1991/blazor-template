using Microsoft.AspNetCore.Components;

namespace BlazorApp.Lib.Razor.Pages;

public abstract class Page<T> : ComponentBase
{
    protected T? Data { get; private set; }

    protected bool Loading { get; private set; } = true;

    protected abstract Task<T?> LoadAsync();

    protected override async Task OnParametersSetAsync()
    {
        Loading = true;
        Data = await LoadAsync();
        Loading = false;
    }
}
