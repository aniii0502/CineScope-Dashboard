using System.Threading.Tasks;
using CineScope.Services.Interfaces;
using CineScope.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CineScope.Controllers;

public class MoviesController : Controller
{
    private readonly IMovieService _movieService;

    public MoviesController(IMovieService movieService)
    {
        _movieService = movieService;
    }

    // GET: /Movies or /Movies?page=2
    public async Task<IActionResult> Index(
        string genre,
        string year,
        string sort = "popularity.desc",
        int page = 1
    )
    {
        ViewData["CurrentGenre"] = genre;
        ViewData["CurrentYear"] = year;
        ViewData["CurrentSort"] = sort;

        var movies = await _movieService.GetFilteredMoviesAsync(genre, year, sort, page);
        if (movies == null)
        {
            return View("Error");
        }

        return View(movies);
    }

    // GET: /Movies/Details/550
    public async Task<IActionResult> Details(int id)
    {
        try
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var movie = await _movieService.GetMovieByIdAsync(id);
            if (movie == null)
            {
                return NotFound();
            }

            var viewModel = new MovieDetailViewModel { Movie = movie };
            return View(viewModel);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
            throw;
        }
    }
}
