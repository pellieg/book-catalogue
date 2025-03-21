using System.Threading.Tasks;
using BookCatalogue.Core.Models;
using BookCatalogue.Core.Service;
using Microsoft.AspNetCore.Mvc;

namespace BookCatalogue.WebUI.Controllers;

public class AuthorController : Controller
{
    private readonly AuthorService authorService;

    public AuthorController(AuthorService authorService)
    {
        this.authorService = authorService;
    }

    public async Task<IActionResult> Index()
    {
        var authors = await authorService.GetAllAuthorsAsync();

        return View(authors);
    }


    public async Task<ActionResult> Details(Guid id)
    {
        var author = await authorService.GetAuthorByIdAsync(id);

        return View(author);
    }

    public async Task<ActionResult> Edit(Guid id)
    {
        var author = await authorService.GetAuthorByIdAsync(id);
        return View(author);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Edit(Author model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var savedSuccessfully = await authorService.UpdateAuthorAsync(model.Id, model);

        if (savedSuccessfully == true)
        {
            TempData["SuccessMessage"] = "Author saved successfully!";
        }
        else
        {
            throw new Exception("Saving author failed, please try again later.");
        }

        return View(model);
    }
}