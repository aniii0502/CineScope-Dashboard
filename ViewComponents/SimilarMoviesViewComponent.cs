using System.Threading.Tasks;
using CineScope.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CineScope.ViewComponents;

/// <summary>
/// A View Component to display a list of movies similar to a given movie.
/// </summary>
public class SimilarMoviesViewComponent : ViewComponent
{
    private readonly IMovieService _movieService;

    public SimilarMoviesViewComponent(IMovieService movieService)
    {
        _movieService = movieService;
    }

    /// <summary>
    /// Invokes the component to fetch and display similar movies.
    /// </summary>
    /// <param name="movieId">The ID of the movie to find similar titles for.</param>
    /// <returns>A view with a list of similar movies.</returns>
    public async Task<IViewComponentResult> InvokeAsync(int movieId)
    {
        var similarMovies = await _movieService.GetSimilarMoviesAsync(movieId);

        // Pass only the list of results to the component's view.
        return View(similarMovies?.Results);
    }
}
