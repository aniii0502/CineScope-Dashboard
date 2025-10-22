using System.Threading.Tasks;
using CineScope.Models;

namespace CineScope.Services.Interfaces;

/// <summary>
/// Defines the contract for a service that handles person-related data operations.
/// </summary>
public interface IPersonService
{
    /// <summary>
    /// Gets the full details for a specific person by their ID.
    /// </summary>
    /// <param name="id">The unique ID of the person.</param>
    /// <returns>A Person object or null if not found.</returns>
    Task<Person?> GetPersonByIdAsync(int id);
}
