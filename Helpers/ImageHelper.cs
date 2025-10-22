namespace CineScope.Helpers;

/// <summary>
/// A helper to construct full image URLs from TMDB paths.
/// </summary>
public static class ImageHelper
{
    public enum PlaceholderType
    {
        Poster,
        Person,
    }

    private const string ImageBaseUrl = "https://image.tmdb.org/t/p/";
    private const string PosterPlaceholder = "/images/placeholders/default-poster.png";
    private const string PersonPlaceholder = "/images/placeholders/user-placeholder.png";

    /// <summary>
    /// Gets the full URL for a given image path and size.
    /// </summary>
    /// <param name="path">The partial image path from the API (e.g., "/xxxxx.jpg").</param>
    /// <param name="size">The desired image size (e.g., "w500").</param>
    /// <returns>The full image URL or a path to a local placeholder.</returns>
    public static string GetImageUrl(
        string? path,
        string size = "w500",
        PlaceholderType type = PlaceholderType.Poster
    )
    {
        if (string.IsNullOrWhiteSpace(path))
        {
            return type == PlaceholderType.Person ? PersonPlaceholder : PosterPlaceholder;
        }

        return $"{ImageBaseUrl}{size}{path}";
    }
}
