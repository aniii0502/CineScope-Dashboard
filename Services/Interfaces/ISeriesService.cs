using System.Threading.Tasks;
using CineScope.Models;

namespace CineScope.Services.Interfaces;

/// <summary>
/// Defines the contract for a service that handles TV series-related data operations.
/// </summary>
public interface ISeriesService
{
    /// <summary>
    /// Gets a paginated list of popular TV series.
    /// </summary>
    /// <param name="page">The page number to retrieve.</param>
    /// <returns>A PaginatedSeries object or null if the request fails.</returns>
    Task<PaginatedSeries?> GetPopularSeriesAsync(int page = 1);

    /// <summary>
    /// Gets a paginated list of top-rated TV series.
    /// </summary>
    /// <param name="page">The page number to retrieve.</param>
    /// <returns>A PaginatedSeries object or null if the request fails.</returns>
    Task<PaginatedSeries?> GetTopRatedSeriesAsync(int page = 1);

    /// <summary>
    /// Gets the full details for a specific series by its ID.
    /// </summary>
    /// <param name="id">The unique ID of the series.</param>
    /// <returns>A Series object or null if not found.</returns>
    Task<Series?> GetSeriesByIdAsync(int id);

    /// <summary>
    /// Gets a paginated list of series similar to a specified series.
    /// </summary>
    /// <param name="seriesId">The ID of the series to find similar titles for.</param>
    /// <param name="page">The page number to retrieve.</param>
    /// <returns>A PaginatedSeries object or null if the request fails.</returns>
    Task<PaginatedSeries?> GetFilteredSeriesAsync(
        string? genre,
        string? year,
        string? sort,
        int page = 1
    );
    Task<PaginatedSeries?> GetSimilarSeriesAsync(int seriesId, int page = 1);
}
