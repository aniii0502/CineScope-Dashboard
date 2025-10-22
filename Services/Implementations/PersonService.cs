using System.Threading.Tasks;
using CineScope.Config;
using CineScope.Helpers;
using CineScope.Mappers;
using CineScope.Models;
using CineScope.Services.Interfaces;
using Microsoft.Extensions.Options;

namespace CineScope.Services.Implementations;

public class PersonService : IPersonService
{
    private readonly HttpHelper _httpHelper;
    private readonly string _apiKey;

    public PersonService(HttpHelper httpHelper, IOptions<ApiKeys> apiKeys)
    {
        _httpHelper = httpHelper;
        _apiKey =
            apiKeys.Value.TmdbApiKey
            ?? throw new InvalidOperationException("TMDB API key is not configured.");
    }

    public async Task<Person?> GetPersonByIdAsync(int id)
    {
        var url = ApiEndpoints.PersonDetails(_apiKey, id);
        var personDto = await _httpHelper.GetAsync<PersonDto>(url);
        return personDto != null ? PersonMapper.MapToModel(personDto) : null;
    }
}
