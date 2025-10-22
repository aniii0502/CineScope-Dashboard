using System.Collections.Generic;

namespace CineScope.Models;

public enum SearchResultType
{
    Movie,
    Series,
    Person,
}

/// <summary>
/// Represents a single search result item, acting as a container for a full Movie, Series, or Person object.
/// </summary>
public class SearchResultItem
{
    public SearchResultType Type { get; set; }
    public Movie? Movie { get; set; }
    public Series? Series { get; set; }
    public Person? Person { get; set; }
}

/// <summary>
/// Represents a paginated set of search results.
/// </summary>
public class PaginatedSearchResult
{
    public int Page { get; set; }
    public List<SearchResultItem> Results { get; set; } = new List<SearchResultItem>();
    public int TotalPages { get; set; }
    public int TotalResults { get; set; }
}
