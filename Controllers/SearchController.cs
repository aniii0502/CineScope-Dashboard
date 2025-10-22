using System.Linq;
using System.Threading.Tasks;
using CineScope.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CineScope.Controllers;

public class SearchController : Controller
{
    private readonly ISearchService _searchService;

    public SearchController(ISearchService searchService)
    {
        _searchService = searchService;
    }

    // GET: /Search?q=dune&category=movie&page=1
    public async Task<IActionResult> Index(string q, string category = "all", int page = 1)
    {
        ViewData["CurrentQuery"] = q;
        ViewData["CurrentCategory"] = category;

        if (string.IsNullOrWhiteSpace(q))
        {
            return View();
        }

        var searchResults = await _searchService.SearchAsync(q, page);
        if (searchResults == null)
        {
            return View();
        }

        // --- FILTERING LOGIC ---
        if (category.ToLower() != "all")
        {
            searchResults.Results = searchResults
                .Results.Where(r => r.Type.ToString().ToLower() == category.ToLower())
                .ToList();
        }

        return View(searchResults);
    }
}
