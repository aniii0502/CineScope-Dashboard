namespace CineScope.Models;

public class PaginatedSeries
{
    public int Page { get; set; }
    public List<Series> Results { get; set; } = new List<Series>();
    public int TotalPages { get; set; }
    public int TotalResults { get; set; }
}
