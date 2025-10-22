namespace CineScope.Models;

public class Person
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Character { get; set; } 
    public string? Biography { get; set; }
    public string? ProfilePath { get; set; }
    public string? KnownForDepartment { get; set; }
    public string? Birthday { get; set; }
    public string? PlaceOfBirth { get; set; }
    public List<MovieCredit> MovieCredits { get; set; } = new();
    public List<SeriesCredit> SeriesCredits { get; set; } = new();
}
