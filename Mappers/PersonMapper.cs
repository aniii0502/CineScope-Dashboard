using System.Linq;
using CineScope.Models;

namespace CineScope.Mappers;

public static class PersonMapper
{
    public static Person MapToModel(PersonDto dto)
    {
        var movieCredits =
            dto.MovieCredits?.Cast?.Select(c => new MovieCredit
                {
                    Id = c.Id,
                    Title = c.Title ?? "Unknown Title",
                    PosterPath = c.PosterPath,
                    Character = c.Character,
                    ReleaseDate = c.ReleaseDate,
                })
                .OrderByDescending(c => c.ReleaseDate)
                .ToList() ?? new List<MovieCredit>();

        var seriesCredits =
            dto.TvCredits?.Cast?.Select(c => new SeriesCredit
                {
                    Id = c.Id,
                    Name = c.Name ?? "Unknown Name",
                    PosterPath = c.ProfilePath,
                    Character = c.Character,
                    FirstAirDate = c.FirstAirDate,
                })
                .OrderByDescending(c => c.FirstAirDate)
                .ToList() ?? new List<SeriesCredit>();

        return new Person
        {
            Id = dto.Id,
            Name = dto.Name ?? "Unknown",
            Biography = dto.Biography,
            ProfilePath = dto.ProfilePath,
            KnownForDepartment = dto.KnownForDepartment,
            Birthday = dto.Birthday,
            PlaceOfBirth = dto.PlaceOfBirth,
            MovieCredits = movieCredits,
            SeriesCredits = seriesCredits,
        };
    }
}
