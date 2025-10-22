using System.Diagnostics;
using System.Threading.Tasks;
using CineScope.Models;
using CineScope.Services.Interfaces;
using CineScope.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CineScope.Controllers;

public class HomeController : Controller
{
    private readonly IMovieService _movieService;
    private readonly ISeriesService _seriesService;

    public HomeController(IMovieService movieService, ISeriesService seriesService)
    {
        _movieService = movieService;
        _seriesService = seriesService;
    }

    public async Task<IActionResult> Index()
    {
        var popularMoviesTask = _movieService.GetPopularMoviesAsync(1);
        var topRatedSeriesTask = _seriesService.GetTopRatedSeriesAsync(1);
        var upcomingMoviesTask = _movieService.GetUpcomingMoviesAsync(1);

        await Task.WhenAll(popularMoviesTask, topRatedSeriesTask, upcomingMoviesTask);

        var viewModel = new HomeViewModel
        {
            PopularMovies = popularMoviesTask.Result?.Results ?? new List<Movie>(),
            TopRatedSeries = topRatedSeriesTask.Result?.Results ?? new List<Series>(),
            UpcomingMovies = upcomingMoviesTask.Result?.Results ?? new List<Movie>(),
        };

        return View(viewModel);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(
            new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier }
        );
    }

    public IActionResult About()
    {
        return View();
    }
}
