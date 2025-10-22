using System.Globalization;

namespace CineScope.Helpers;

/// <summary>
/// Provides utility methods for parsing and formatting date strings.
/// </summary>
public static class DateFormatter
{
    /// <summary>
    /// Formats a date string (like "2023-10-26") into a more readable format (like "2023").
    /// Returns a fallback string if the date is null or invalid.
    /// </summary>
    /// <param name="dateString">The date string from the API.</param>
    /// <param name="fallback">The string to return if parsing fails.</param>
    /// <returns>The formatted year or a fallback string.</returns>
    public static string GetYear(string? dateString, string fallback = "N/A")
    {
        if (string.IsNullOrWhiteSpace(dateString))
        {
            return fallback;
        }

        if (DateTime.TryParse(dateString, out DateTime result))
        {
            return result.ToString("yyyy");
        }

        return fallback;
    }
}
