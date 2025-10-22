using System.Threading.Tasks;
using CineScope.Services.Interfaces;
using CineScope.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CineScope.Controllers;

public class SeriesController : Controller
{
    private readonly ISeriesService _seriesService;

    public SeriesController(ISeriesService seriesService)
    {
        _seriesService = seriesService;
    }

    // GET: /Series or /Series?page=2
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

        var series = await _seriesService.GetFilteredSeriesAsync(genre, year, sort, page);
        if (series == null)
        {
            return View("Error");
        }

        return View(series);
    }

    // GET: /Series/Details/1396
    public async Task<IActionResult> Details(int id)
    {
        if (id == 0)
        {
            return BadRequest();
        }

        var series = await _seriesService.GetSeriesByIdAsync(id);
        if (series == null)
        {
            return NotFound();
        }

        var viewModel = new SeriesDetailViewModel { Series = series };

        return View(viewModel);
    }
}
