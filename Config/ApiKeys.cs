namespace CineScope.Config;

/// <summary>
/// Holds API keys and other secrets for external services.
/// It's designed to be mapped from the appsettings.json "ApiKeys" section.
/// </summary>
public class ApiKeys
{
    public string? TmdbApiKey { get; set; }
}
