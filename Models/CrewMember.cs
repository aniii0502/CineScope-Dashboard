namespace CineScope.Models;

public class CrewMember
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Job { get; set; } = string.Empty;
    public string Department { get; set; } = string.Empty;
    public string? ProfilePath { get; set; }
}
