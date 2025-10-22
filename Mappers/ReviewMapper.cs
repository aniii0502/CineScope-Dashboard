using System.Linq;
using CineScope.Models;

namespace CineScope.Mappers;

// Represents the structure of a single review from the TMDB API response

/// <summary>
/// Maps review-related API data to the application's Review model.
/// </summary>
public static class ReviewMapper
{
    public static Review MapToModel(ReviewDto dto)
    {
        return new Review
        {
            Author = dto.Author ?? "Anonymous",
            Content = dto.Content ?? string.Empty,
            Url = dto.Url,
        };
    }
}
