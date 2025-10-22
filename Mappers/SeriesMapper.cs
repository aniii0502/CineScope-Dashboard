using System.Linq;
using CineScope.Models;

namespace CineScope.Mappers;

public static class SeriesMapper
{
    public static Series MapToModel(SeriesDto dto)
    {
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

        return new Series
        {
            Id = dto.Id,
            Name = dto.Name ?? "No Title",
            Overview = dto.Overview ?? string.Empty,
            PosterPath = dto.PosterPath,
            BackdropPath = dto.BackdropPath,
            VoteAverage = dto.VoteAverage,
            FirstAirDate = dto.FirstAirDate,
            TrailerKey = trailerKey,
            NumberOfSeasons = dto.NumberOfSeasons,
            NumberOfEpisodes = dto.NumberOfEpisodes,
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
            Crew = crew,
            Trivia = new List<string>
            {
                "The TMDB API does not provide a standard trivia field for series. This data would need to be sourced elsewhere.",
            },
        };
    }
}
