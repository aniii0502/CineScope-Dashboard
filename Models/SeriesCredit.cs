namespace CineScope.Models;

public class SeriesCredit
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? PosterPath { get; set; }
    public string? Character { get; set; }
    public string? FirstAirDate { get; set; } 
}
