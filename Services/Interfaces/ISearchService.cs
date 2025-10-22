using System.Threading.Tasks;
using CineScope.Models; // You will need to create PaginatedSearchResult in your Models folder.

namespace CineScope.Services.Interfaces;

/// <summary>
/// Defines the contract for a service that handles search operations.
/// </summary>
public interface ISearchService
{
    /// <summary>
    /// Performs a multi-search across movies, series, and people for a given query.
    /// </summary>
    /// <param name="query">The search term.</param>
    /// <param name="page">The page number of results to retrieve.</param>
    /// <returns>A PaginatedSearchResult object containing mixed results, or null.</returns>
    Task<PaginatedSearchResult?> SearchAsync(string query, int page = 1);
}
