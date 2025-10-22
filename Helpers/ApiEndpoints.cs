using System;

namespace CineScope.Helpers
{
    public static class ApiEndpoints
    {
        private const string ApiBaseUrl = "https://api.themoviedb.org/3/";

        public static string PopularMovies(string apiKey, int page = 1) =>
            $"{ApiBaseUrl}movie/popular?api_key={apiKey}&language=en-US&page={page}";

        public static string TopRatedMovies(string apiKey, int page = 1) =>
            $"{ApiBaseUrl}movie/top_rated?api_key={apiKey}&language=en-US&page={page}";

        public static string UpcomingMovies(string apiKey, int page = 1) =>
            $"{ApiBaseUrl}movie/upcoming?api_key={apiKey}&language=en-US&page={page}";

        public static string MovieDetails(string apiKey, int movieId) =>
            $"{ApiBaseUrl}movie/{movieId}?api_key={apiKey}&language=en-US&append_to_response=credits,videos,keywords";

        public static string SimilarMovies(string apiKey, int movieId, int page = 1) =>
            $"{ApiBaseUrl}movie/{movieId}/similar?api_key={apiKey}&language=en-US&page={page}";

        public static string MovieVideos(string apiKey, int movieId) =>
            $"{ApiBaseUrl}movie/{movieId}/videos?api_key={apiKey}&language=en-US";

        public static string DiscoverMovies(
            string apiKey,
            string? genre,
            string? year,
            string? sort,
            int page = 1
        ) =>
            $"{ApiBaseUrl}discover/movie?api_key={apiKey}&language=en-US&with_genres={genre}&primary_release_year={year}&sort_by={sort}&page={page}";

        public static string DiscoverSeries(
            string apiKey,
            string? genre,
            string? year,
            string? sort,
            int page = 1
        ) =>
            $"{ApiBaseUrl}discover/tv?api_key={apiKey}&language=en-US&with_genres={genre}&first_air_date_year={year}&sort_by={sort}&page={page}";

        public static string PopularSeries(string apiKey, int page = 1) =>
            $"{ApiBaseUrl}tv/popular?api_key={apiKey}&language=en-US&page={page}";

        public static string TopRatedSeries(string apiKey, int page = 1) =>
            $"{ApiBaseUrl}tv/top_rated?api_key={apiKey}&language=en-US&page={page}";

        public static string SeriesDetails(string apiKey, int seriesId) =>
            $"{ApiBaseUrl}tv/{seriesId}?api_key={apiKey}&language=en-US&append_to_response=credits,reviews,videos";

        public static string SimilarSeries(string apiKey, int seriesId, int page = 1) =>
            $"{ApiBaseUrl}tv/{seriesId}/similar?api_key={apiKey}&language=en-US&page={page}";

        public static string SeriesVideos(string apiKey, int seriesId) =>
            $"{ApiBaseUrl}tv/{seriesId}/videos?api_key={apiKey}&language=en-US";

        public static string PersonDetails(string apiKey, int personId) =>
            $"{ApiBaseUrl}person/{personId}?api_key={apiKey}&language=en-US&append_to_response=movie_credits,tv_credits";

        public static string Trending(string apiKey, string timeWindow = "day") =>
            $"{ApiBaseUrl}trending/all/{timeWindow}?api_key={apiKey}";

        public static string SearchMulti(string apiKey, string query, int page = 1) =>
            $"{ApiBaseUrl}search/multi?api_key={apiKey}&language=en-US&query={Uri.EscapeDataString(query)}&page={page}";

        public static string Genres(string apiKey, string type = "movie") =>
            $"{ApiBaseUrl}genre/{type}/list?api_key={apiKey}&language=en-US";
    }
}
