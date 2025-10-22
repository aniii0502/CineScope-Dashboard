using System.Collections.Generic;
using CineScope.Models;

namespace CineScope.ViewModels;

/// <summary>
/// Represents all the data required for the Home page.
/// </summary>
public class HomeViewModel
{
    public List<Movie> PopularMovies { get; set; } = new List<Movie>();
    public List<Series> TopRatedSeries { get; set; } = new List<Series>();
    public List<Movie> UpcomingMovies { get; set; } = new List<Movie>();
}
