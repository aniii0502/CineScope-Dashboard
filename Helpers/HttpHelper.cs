using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace CineScope.Helpers;

/// <summary>
/// A helper class to manage HttpClient requests and JSON deserialization.
/// This should be registered as a scoped or transient service in Program.cs.
/// </summary>
public class HttpHelper
{
    private readonly IHttpClientFactory _httpClientFactory;

    public HttpHelper(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    /// <summary>
    /// Performs an HTTP GET request to the specified URL and deserializes the JSON response.
    /// </summary>
    /// <typeparam name="T">The type to deserialize the JSON into.</typeparam>
    /// <param name="url">The request URL.</param>
    /// <returns>A deserialized object of type T, or null if the request fails.</returns>
    public async Task<T?> GetAsync<T>(string url)
        where T : class
    {
        var client = _httpClientFactory.CreateClient("TMDB");

        try
        {
            var response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();

            var jsonResponse = await response.Content.ReadAsStringAsync();

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower,
            };

            return JsonSerializer.Deserialize<T>(jsonResponse, options);
        }
        catch (HttpRequestException ex)
        {
            System.Diagnostics.Debug.WriteLine($"HTTP request failed: {ex.Message}");
            return null;
        }
    }
}
