using System.Threading.Tasks;
using CineScope.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CineScope.ViewComponents;

public class SimilarSeriesViewComponent : ViewComponent
{
    private readonly ISeriesService _seriesService;

    public SimilarSeriesViewComponent(ISeriesService seriesService)
    {
        _seriesService = seriesService;
    }

    public async Task<IViewComponentResult> InvokeAsync(int seriesId)
    {
        var similarSeries = await _seriesService.GetSimilarSeriesAsync(seriesId);

        return View(similarSeries?.Results);
    }
}
