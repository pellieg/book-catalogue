using BookCatalogue.WebUI.Services;
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
}