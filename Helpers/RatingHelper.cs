using System;

namespace CineScope.Helpers;

/// <summary>
/// Provides utility methods for formatting ratings.
/// </summary>
public static class RatingHelper
{
    /// <summary>
    /// Converts a vote average (out of 10) to a percentage string (e.g., 8.4 -> "84%").
    /// </summary>
    /// <param name="voteAverage">The rating score, typically out of 10.</param>
    /// <returns>A formatted percentage string.</returns>
    public static string ToPercentage(double voteAverage)
    {
        if (voteAverage < 0 || voteAverage > 10)
        {
            return "0%";
        }

        int percentage = (int)Math.Round(voteAverage * 10);
        return $"{percentage}%";
    }
}
