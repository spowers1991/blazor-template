namespace BlazorApp.Lib.Sanity.Clients;

public class SanityClient
{
    private readonly HttpClient _http;
    private readonly ILogger<SanityClient> _logger;
    private readonly string _projectId;
    private readonly string _dataset;

    public SanityClient(HttpClient http, IConfiguration config, ILogger<SanityClient> logger)
    {
        _http = http;
        _logger = logger;
        _projectId = config["Sanity:ProjectId"] ?? throw new InvalidOperationException("Sanity:ProjectId is not configured.");
        _dataset = config["Sanity:Dataset"] ?? throw new InvalidOperationException("Sanity:Dataset is not configured.");
    }

    public async Task<string> QueryAsync(string groq)
    {
        var url = $"https://{_projectId}.apicdn.sanity.io/v2024-01-01/data/query/{_dataset}?query={Uri.EscapeDataString(groq)}";
        var response = await _http.GetAsync(url);
        var body = await response.Content.ReadAsStringAsync();
        _logger.LogInformation("Sanity response ({Status})", (int)response.StatusCode);
        return body;
    }
}
