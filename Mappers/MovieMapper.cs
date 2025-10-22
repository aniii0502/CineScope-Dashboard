using System.Linq;
using CineScope.Models;

namespace CineScope.Mappers;

public static class MovieMapper
{
    public static Movie MapToModel(MovieDto dto)
    {
        var directors =
            dto.Credits?.Crew?.Where(c => c.Job == "Director")
                .Select(c => new Director { Id = c.Id, Name = c.Name ?? "Unknown" })
                .ToList() ?? new List<Director>();
        var trailerKey = dto
            .Videos?.Results?.FirstOrDefault(v => v.Site == "YouTube" && v.Type == "Trailer")
            ?.Key;
        var crew =
            dto.Credits?.Crew?.Select(c => new CrewMember
                {
                    Id = c.Id,
                    Name = c.Name ?? "Unknown",
                    Job = c.Job ?? "N/A",
                    Department = c.Department ?? "N/A",
                    ProfilePath = c.ProfilePath,
                })
                .ToList() ?? new List<CrewMember>();

        return new Movie
        {
            Id = dto.Id,
            Title = dto.Title ?? "No Title",
            Overview = dto.Overview ?? string.Empty,
            PosterPath = dto.PosterPath,
            BackdropPath = dto.BackdropPath,
            VoteAverage = dto.VoteAverage,
            ReleaseDate = dto.ReleaseDate,
            TrailerKey = trailerKey,
            Runtime = dto.Runtime,
            Status = dto.Status ?? "N/A",
            OriginalLanguage = dto.OriginalLanguage ?? "N/A",
            ProductionCompanies =
                dto.ProductionCompanies?.Select(p => new ProductionCompany
                    {
                        Id = p.Id,
                        Name = p.Name ?? "N/A",
                    })
                    .ToList() ?? new List<ProductionCompany>(),
            Keywords =
                dto.Keywords?.Keywords?.Select(k => new Keyword
                    {
                        Id = k.Id,
                        Name = k.Name ?? "N/A",
                    })
                    .ToList() ?? new List<Keyword>(),
            Genres =
                dto.Genres?.Select(g => new Genre { Id = g.Id, Name = g.Name ?? "Unknown" })
                    .ToList() ?? new List<Genre>(),
            Cast =
                dto.Credits?.Cast?.Select(c => new Person
                    {
                        Id = c.Id,
                        Name = c.Name ?? "Unknown",
                        Character = c.Character ?? "N/A",
                        ProfilePath = c.ProfilePath,
                    })
                    .ToList() ?? new List<Person>(),
            Directors = directors,
            Crew = crew,
            BoxOfficeInfo = new BoxOffice
            {
                Budget = dto.Budget > 0 ? $"${dto.Budget:N0}" : "N/A",
                Revenue = dto.Revenue > 0 ? $"${dto.Revenue:N0}" : "N/A",
            },
            Trivia = new List<string>
            {
                "The TMDB API does not provide a standard trivia field. This data would need to be sourced elsewhere.",
            },
        };
    }
}
