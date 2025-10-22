using System.Threading.Tasks;
using CineScope.Models;

namespace CineScope.Services.Interfaces;

/// <summary>
/// Defines the contract for a service that handles movie-related data operations.
/// </summary>
public interface IMovieService
{
    /// <summary>
    /// Gets a paginated list of popular movies.
    /// </summary>
    /// <param name="page">The page number to retrieve.</param>
    /// <returns>A PaginatedMovies object or null if the request fails.</returns>
    Task<PaginatedMovies?> GetPopularMoviesAsync(int page = 1);

    /// <summary>
    /// Gets a paginated list of top-rated movies.
    /// </summary>
    /// <param name="page">The page number to retrieve.</param>
    /// <returns>A PaginatedMovies object or null if the request fails.</returns>
    Task<PaginatedMovies?> GetTopRatedMoviesAsync(int page = 1);

    /// <summary>
    /// Gets a paginated list of upcoming movies.
    /// </summary>
    /// <param name="page">The page number to retrieve.</param>
    /// <returns>A PaginatedMovies object or null if the request fails.</returns>
    Task<PaginatedMovies?> GetUpcomingMoviesAsync(int page = 1);

    /// <summary>
    /// Gets the full details for a specific movie by its ID.
    /// </summary>
    /// <param name="id">The unique ID of the movie.</param>
    /// <returns>A Movie object or null if not found.</returns>
    Task<Movie?> GetMovieByIdAsync(int id);

    /// <summary>
    /// Gets a paginated list of movies similar to a specified movie.
    /// </summary>
    /// <param name="movieId">The ID of the movie to find similar titles for.</param>
    /// <param name="page">The page number to retrieve.</param>
    /// <returns>A PaginatedMovies object or null if the request fails.</returns>
    Task<PaginatedMovies?> GetSimilarMoviesAsync(int movieId, int page = 1);
    Task<PaginatedMovies?> GetFilteredMoviesAsync(
        string? genre,
        string? year,
        string? sort,
        int page = 1
    );
}
