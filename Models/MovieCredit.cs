namespace CineScope.Models;

public class MovieCredit
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string? PosterPath { get; set; }
    public string? Character { get; set; }
    public string? ReleaseDate { get; set; }
}
