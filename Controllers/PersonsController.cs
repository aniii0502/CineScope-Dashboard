using System.Threading.Tasks;
using CineScope.Services.Interfaces;
using CineScope.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CineScope.Controllers;

public class PersonsController : Controller
{
    private readonly IPersonService _personService;

    public PersonsController(IPersonService personService)
    {
        _personService = personService;
    }

    // GET: /Persons/Details/6384
    public async Task<IActionResult> Details(int id)
    {
        if (id == 0)
        {
            return BadRequest();
        }

        var person = await _personService.GetPersonByIdAsync(id);
        if (person == null)
        {
            return NotFound();
        }

        var viewModel = new PersonDetailViewModel { Person = person };

        return View(viewModel);
    }
}
