using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using CineScope.Config;
using CineScope.Helpers;
using CineScope.Mappers;
using CineScope.Models;
using CineScope.Services.Interfaces;
using Microsoft.Extensions.Options;

namespace CineScope.Services.Implementations;


public class SearchService : ISearchService
{
    private readonly HttpHelper _httpHelper;
    private readonly string _apiKey;
    private readonly JsonSerializerOptions _jsonOptions;

    public SearchService(HttpHelper httpHelper, IOptions<ApiKeys> apiKeys)
    {
        _httpHelper = httpHelper;
        _apiKey =
            apiKeys.Value.TmdbApiKey
            ?? throw new InvalidOperationException("TMDB API key is not configured.");
        _jsonOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower,
        };
    }

    public async Task<PaginatedSearchResult?> SearchAsync(string query, int page = 1)
    {
        var url = ApiEndpoints.SearchMulti(_apiKey, query, page);
        var responseDto = await _httpHelper.GetAsync<PaginatedSearchResponseDto>(url);

        if (responseDto == null)
            return null;

        var searchResultItems = new List<SearchResultItem>();

        foreach (var element in responseDto.Results)
        {
            var mediaType = element.GetProperty("media_type").GetString();
            SearchResultItem? item = null;

            switch (mediaType)
            {
                case "movie":
                    var movieDto = element.Deserialize<MovieDto>(_jsonOptions);
                    if (movieDto != null)
                    {
                        var movie = MovieMapper.MapToModel(movieDto);
                        item = new SearchResultItem
                        {
                            Type = SearchResultType.Movie,
                            Movie = movie,
                        };
                    }
                    break;

                case "tv":
                    var seriesDto = element.Deserialize<SeriesDto>(_jsonOptions);
                    if (seriesDto != null)
                    {
                        var series = SeriesMapper.MapToModel(seriesDto);
                        item = new SearchResultItem
                        {
                            Type = SearchResultType.Series,
                            Series = series,
                        };
                    }
                    break;

                case "person":
                    var personDto = element.Deserialize<PersonDto>(_jsonOptions);
                    if (personDto != null)
                    {
                        var person = PersonMapper.MapToModel(personDto);
                        item = new SearchResultItem
                        {
                            Type = SearchResultType.Person,
                            Person = person,
                        };
                    }
                    break;
            }

            // Only add known and valid media types
            if (item != null)
                searchResultItems.Add(item);
        }

        return new PaginatedSearchResult
        {
            Page = responseDto.Page,
            TotalPages = responseDto.TotalPages,
            TotalResults = responseDto.TotalResults,
            Results = searchResultItems,
        };
    }
}
