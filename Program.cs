using Blazorise;
using Blazorise.Bootstrap5;
using BlazorApp.Components;
using BlazorApp.Lib.Sanity.Clients;
using BlazorApp.Services.Weather.Forecasts;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddControllers();
builder.Services.AddBlazorise().AddBootstrap5Providers();
builder.Services.AddSingleton<Forecasts>();
builder.Services.AddHttpClient("Default", client =>
{
    client.BaseAddress = new Uri(builder.Configuration["AppBaseUrl"] ?? builder.Configuration["ASPNETCORE_URLS"] ?? "https://localhost:5001/");
});

builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("Default"));

builder.Services.AddHttpClient<SanityClient>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/not-found");
app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapControllers();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
