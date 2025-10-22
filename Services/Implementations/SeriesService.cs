using System.Linq;
using System.Threading.Tasks;
using CineScope.Config;
using CineScope.Helpers;
using CineScope.Mappers;
using CineScope.Models;
using CineScope.Services.Interfaces;
using Microsoft.Extensions.Options;

namespace CineScope.Services.Implementations;

public class SeriesService : ISeriesService
{
    private readonly HttpHelper _httpHelper;
    private readonly string _apiKey;

    public SeriesService(HttpHelper httpHelper, IOptions<ApiKeys> apiKeys)
    {
        _httpHelper = httpHelper;
        _apiKey =
            apiKeys.Value.TmdbApiKey
            ?? throw new InvalidOperationException("TMDB API key is not configured.");
    }

    public async Task<Series?> GetSeriesByIdAsync(int id)
    {
        var url = ApiEndpoints.SeriesDetails(_apiKey, id);
        var seriesDto = await _httpHelper.GetAsync<SeriesDto>(url);
        return seriesDto != null ? SeriesMapper.MapToModel(seriesDto) : null;
    }

    public async Task<PaginatedSeries?> GetPopularSeriesAsync(int page = 1)
    {
        var url = ApiEndpoints.PopularSeries(_apiKey, page);
        var paginatedDto = await _httpHelper.GetAsync<PaginatedResultDto<SeriesDto>>(url);
        if (paginatedDto?.Results == null)
            return null;

        return new PaginatedSeries
        {
            Page = paginatedDto.Page,
            TotalPages = paginatedDto.TotalPages,
            TotalResults = paginatedDto.TotalResults,
            Results = paginatedDto.Results.Select(SeriesMapper.MapToModel).ToList(),
        };
    }

    public async Task<PaginatedSeries?> GetFilteredSeriesAsync(
        string? genre,
        string? year,
        string? sort,
        int page = 1
    )
    {
        var url = ApiEndpoints.DiscoverSeries(_apiKey, genre, year, sort, page);
        var paginatedDto = await _httpHelper.GetAsync<PaginatedResultDto<SeriesDto>>(url);
        if (paginatedDto?.Results == null)
            return null;

        return new PaginatedSeries
        {
            Page = paginatedDto.Page,
            TotalPages = paginatedDto.TotalPages,
            TotalResults = paginatedDto.TotalResults,
            Results = paginatedDto.Results.Select(SeriesMapper.MapToModel).ToList(),
        };
    }

    public async Task<PaginatedSeries?> GetTopRatedSeriesAsync(int page = 1)
    {
        var url = ApiEndpoints.TopRatedSeries(_apiKey, page);
        var paginatedDto = await _httpHelper.GetAsync<PaginatedResultDto<SeriesDto>>(url);
        if (paginatedDto?.Results == null)
            return null;

        return new PaginatedSeries
        {
            Page = paginatedDto.Page,
            TotalPages = paginatedDto.TotalPages,
            TotalResults = paginatedDto.TotalResults,
            Results = paginatedDto.Results.Select(SeriesMapper.MapToModel).ToList(),
        };
    }

    public async Task<PaginatedSeries?> GetSimilarSeriesAsync(int seriesId, int page = 1)
    {
        var url = ApiEndpoints.SimilarSeries(_apiKey, seriesId, page);
        var paginatedDto = await _httpHelper.GetAsync<PaginatedResultDto<SeriesDto>>(url);
        if (paginatedDto?.Results == null)
            return null;

        return new PaginatedSeries
        {
            Page = paginatedDto.Page,
            TotalPages = paginatedDto.TotalPages,
            TotalResults = paginatedDto.TotalResults,
            Results = paginatedDto.Results.Select(SeriesMapper.MapToModel).ToList(),
        };
    }
}
