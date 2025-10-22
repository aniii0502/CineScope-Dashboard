using System.Linq;
using System.Threading.Tasks;
using CineScope.Config;
using CineScope.Helpers;
using CineScope.Mappers;
using CineScope.Models;
using CineScope.Services.Interfaces;
using Microsoft.Extensions.Options;

namespace CineScope.Services.Implementations;

public class MovieService : IMovieService
{
    private readonly HttpHelper _httpHelper;
    private readonly string _apiKey;

    public MovieService(HttpHelper httpHelper, IOptions<ApiKeys> apiKeys)
    {
        _httpHelper = httpHelper;
        _apiKey =
            apiKeys.Value.TmdbApiKey
            ?? throw new InvalidOperationException("TMDB API key is not configured.");
    }

    public async Task<Movie?> GetMovieByIdAsync(int id)
    {
        var url = ApiEndpoints.MovieDetails(_apiKey, id);
        var movieDto = await _httpHelper.GetAsync<MovieDto>(url);
        return movieDto != null ? MovieMapper.MapToModel(movieDto) : null;
    }

    public async Task<PaginatedMovies?> GetPopularMoviesAsync(int page = 1)
    {
        var url = ApiEndpoints.PopularMovies(_apiKey, page);
        var paginatedDto = await _httpHelper.GetAsync<PaginatedResultDto<MovieDto>>(url);
        if (paginatedDto?.Results == null)
            return null;

        return new PaginatedMovies
        {
            Page = paginatedDto.Page,
            TotalPages = paginatedDto.TotalPages,
            TotalResults = paginatedDto.TotalResults,
            Results = paginatedDto.Results.Select(MovieMapper.MapToModel).ToList(),
        };
    }

    public async Task<PaginatedMovies?> GetTopRatedMoviesAsync(int page = 1)
    {
        var url = ApiEndpoints.TopRatedMovies(_apiKey, page);
        var paginatedDto = await _httpHelper.GetAsync<PaginatedResultDto<MovieDto>>(url);
        if (paginatedDto?.Results == null)
            return null;

        return new PaginatedMovies
        {
            Page = paginatedDto.Page,
            TotalPages = paginatedDto.TotalPages,
            TotalResults = paginatedDto.TotalResults,
            Results = paginatedDto.Results.Select(MovieMapper.MapToModel).ToList(),
        };
    }

    public async Task<PaginatedMovies?> GetUpcomingMoviesAsync(int page = 1)
    {
        var url = ApiEndpoints.UpcomingMovies(_apiKey, page);
        var paginatedDto = await _httpHelper.GetAsync<PaginatedResultDto<MovieDto>>(url);
        if (paginatedDto?.Results == null)
            return null;

        return new PaginatedMovies
        {
            Page = paginatedDto.Page,
            TotalPages = paginatedDto.TotalPages,
            TotalResults = paginatedDto.TotalResults,
            Results = paginatedDto.Results.Select(MovieMapper.MapToModel).ToList(),
        };
    }

    public async Task<PaginatedMovies?> GetFilteredMoviesAsync(
        string? genre,
        string? year,
        string? sort,
        int page = 1
    )
    {
        var url = ApiEndpoints.DiscoverMovies(_apiKey, genre, year, sort, page);
        var paginatedDto = await _httpHelper.GetAsync<PaginatedResultDto<MovieDto>>(url);
        if (paginatedDto?.Results == null)
            return null;

        return new PaginatedMovies
        {
            Page = paginatedDto.Page,
            TotalPages = paginatedDto.TotalPages,
            TotalResults = paginatedDto.TotalResults,
            Results = paginatedDto.Results.Select(MovieMapper.MapToModel).ToList(),
        };
    }

    public async Task<PaginatedMovies?> GetSimilarMoviesAsync(int movieId, int page = 1)
    {
        var url = ApiEndpoints.SimilarMovies(_apiKey, movieId, page);
        var paginatedDto = await _httpHelper.GetAsync<PaginatedResultDto<MovieDto>>(url);
        if (paginatedDto?.Results == null)
            return null;

        return new PaginatedMovies
        {
            Page = paginatedDto.Page,
            TotalPages = paginatedDto.TotalPages,
            TotalResults = paginatedDto.TotalResults,
            Results = paginatedDto.Results.Select(MovieMapper.MapToModel).ToList(),
        };
    }
}

