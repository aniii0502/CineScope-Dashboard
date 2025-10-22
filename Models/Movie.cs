using System.Collections.Generic;

namespace CineScope.Models;

public class Movie
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Overview { get; set; } = string.Empty;
    public string? PosterPath { get; set; }
    public string? BackdropPath { get; set; }
    public double VoteAverage { get; set; }
    public string? ReleaseDate { get; set; }
    public int Runtime { get; set; }
    public string? TrailerKey { get; set; }
    public BoxOffice? BoxOfficeInfo { get; set; }
    public string Status { get; set; } = string.Empty;
    public string OriginalLanguage { get; set; } = string.Empty;

    public List<Genre> Genres { get; set; } = new List<Genre>();
    public List<Person> Cast { get; set; } = new List<Person>();
    public List<Director> Directors { get; set; } = new List<Director>();
    public List<CrewMember> Crew { get; set; } = new List<CrewMember>();
    public List<ProductionCompany> ProductionCompanies { get; set; } =
        new List<ProductionCompany>();
    public List<Keyword> Keywords { get; set; } = new List<Keyword>();
    public List<string> Trivia { get; set; } = new List<string>();
}
