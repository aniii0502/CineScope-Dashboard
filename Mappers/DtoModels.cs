using System.Text.Json;

namespace CineScope.Mappers;

public class GenreDto
{
    public int Id { get; set; }
    public string? Name { get; set; }
}

public class ProductionCompanyDto
{
    public int Id { get; set; }
    public string? Name { get; set; }
}

public class KeywordDto
{
    public int Id { get; set; }
    public string? Name { get; set; }
}

public class KeywordsResponse
{
    public KeywordDto[]? Keywords { get; set; }
}

public class VideoDto
{
    public string? Key { get; set; }
    public string? Site { get; set; }
    public string? Type { get; set; }
}

public class VideosResponse
{
    public VideoDto[]? Results { get; set; }
}

public class ReviewDto
{
    public string? Author { get; set; }
    public string? Content { get; set; }
    public string? Url { get; set; }
}

public class ReviewsResponse
{
    public ReviewDto[]? Results { get; set; }
}

public class CastMemberDto
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? ProfilePath { get; set; }
    public string? Character { get; set; }
    public string? Title { get; set; }
    public string? ReleaseDate { get; set; }

    // For Series
    public string? FirstAirDate { get; set; }

    // For both Movie & Series posters
    public string? PosterPath { get; set; }
}

public class CrewMemberDto
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Job { get; set; }
    public string? Department { get; set; }
    public string? ProfilePath { get; set; }
}

public class CreditsWithCrewDto
{
    public CastMemberDto[]? Cast { get; set; }
    public CrewMemberDto[]? Crew { get; set; }
}

public class MovieDto
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Overview { get; set; }
    public string? PosterPath { get; set; }
    public string? BackdropPath { get; set; }
    public double VoteAverage { get; set; }
    public string? ReleaseDate { get; set; }
    public int Runtime { get; set; }
    public long Revenue { get; set; }
    public long Budget { get; set; }
    public string? Status { get; set; }
    public string? OriginalLanguage { get; set; }
    public ProductionCompanyDto[]? ProductionCompanies { get; set; }
    public GenreDto[]? Genres { get; set; }
    public CreditsWithCrewDto? Credits { get; set; }
    public VideosResponse? Videos { get; set; }
    public ReviewsResponse? Reviews { get; set; }
    public KeywordsResponse? Keywords { get; set; }
}

public class SeriesDto
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Overview { get; set; }
    public string? PosterPath { get; set; }
    public string? BackdropPath { get; set; }
    public double VoteAverage { get; set; }
    public string? FirstAirDate { get; set; }
    public int NumberOfSeasons { get; set; }
    public int NumberOfEpisodes { get; set; }
    public string? Status { get; set; }
    public string? OriginalLanguage { get; set; }
    public ProductionCompanyDto[]? ProductionCompanies { get; set; }
    public GenreDto[]? Genres { get; set; }
    public CreditsWithCrewDto? Credits { get; set; }
    public VideosResponse? Videos { get; set; }
    public ReviewsResponse? Reviews { get; set; }
    public KeywordsResponse? Keywords { get; set; }
}

public class PersonDto
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Biography { get; set; }
    public string? ProfilePath { get; set; }
    public string? KnownForDepartment { get; set; }
    public string? Birthday { get; set; }
    public string? PlaceOfBirth { get; set; }
    public CreditsWithCrewDto? MovieCredits { get; set; }
    public CreditsWithCrewDto? TvCredits { get; set; }
}

public class PaginatedResultDto<T>
{
    public int Page { get; set; }
    public List<T> Results { get; set; } = new();
    public int TotalPages { get; set; }
    public int TotalResults { get; set; }
}

public class PaginatedSearchResponseDto
{
    public int Page { get; set; }
    public List<JsonElement> Results { get; set; } = new();
    public int TotalPages { get; set; }
    public int TotalResults { get; set; }
}
