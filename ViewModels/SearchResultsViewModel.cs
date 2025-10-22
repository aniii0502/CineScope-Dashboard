using CineScope.Models;

namespace CineScope.ViewModels;

/// <summary>
/// Represents the data needed for the Search Results page.
/// </summary>
public class SearchResultsViewModel
{
    public string Query { get; set; } = string.Empty;
    public PaginatedSearchResult? SearchResult { get; set; }
}
