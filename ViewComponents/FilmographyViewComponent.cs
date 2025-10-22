using System.Threading.Tasks;
using CineScope.Models; // Assuming your updated Person model is here
using CineScope.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CineScope.ViewComponents;


/// <summary>
/// A View Component to display the filmography for a specific person.
/// </summary>
public class FilmographyViewComponent : ViewComponent
{
    private readonly IPersonService _personService;

    public FilmographyViewComponent(IPersonService personService)
    {
        _personService = personService;
    }

    /// <summary>
    /// Invokes the component to fetch a person's details including their filmography.
    /// </summary>
    /// <param name="personId">The ID of the person whose filmography to display.</param>
    /// <returns>A view containing the person model with their credits.</returns>
    public async Task<IViewComponentResult> InvokeAsync(int personId)
    {
        // This call fetches the person's details. The mapper is responsible for
        // processing the appended "movie_credits" and "tv_credits" from the API response
        // and populating the lists in the Person model.
        var personWithCredits = await _personService.GetPersonByIdAsync(personId);

        return View(personWithCredits);
    }
}
