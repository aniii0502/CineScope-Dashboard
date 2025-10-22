namespace CineScope.Config;

/// <summary>
/// Provides application-wide constants to avoid magic strings in the code.
/// </summary>
public static class Constants
{
    public const string TmdbApiBaseUrl = "https://api.themoviedb.org/3/";
    public const string TmdbImageBaseUrl = "https://image.tmdb.org/t/p/";

    // Example image sizes for constructing full image URLs
    public const string PosterSizeW500 = "w500";
    public const string BackdropSizeW1280 = "w1280";
    public const string ProfileSizeW185 = "w185";

    // A default placeholder to use if an image path is null or empty
    public const string PlaceholderImageUrl = "/images/placeholders/default-poster.png";
}
