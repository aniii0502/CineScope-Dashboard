using System.Collections.Generic;
using CineScope.Models;

namespace CineScope.ViewModels;

/// <summary>
/// Represents the data needed for the Movie Details page.
/// </summary>
public class MovieDetailViewModel
{
    public Movie? Movie { get; set; }
    public List<Movie> SimilarMovies { get; set; } = new List<Movie>();
}
