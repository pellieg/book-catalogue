using System.Reflection;
using System.Threading.Tasks;
using BookCatalogue.Core.Models;
using BookCatalogue.Core.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace BookCatalogue.WebUI.Controllers;

public class AuthorController : Controller
{
    private readonly AuthorService authorService;
    private IWebHostEnvironment _hostEnvironment;

    public AuthorController(AuthorService authorService, IWebHostEnvironment hostEnvironment)
    {
        this.authorService = authorService;
        _hostEnvironment = hostEnvironment;
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
    public async Task<ActionResult> Edit(Author model, IFormFile imageUrl)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        // Check if an image was uploaded
        if (imageUrl != null && imageUrl.Length > 0)
        {
            // Define the folder to store the images
            var uploadsFolder = Path.Combine(_hostEnvironment.WebRootPath, "author-images");

            // Ensure the folder exists
            if (!Directory.Exists(uploadsFolder))
            {
                Directory.CreateDirectory(uploadsFolder);
            }

            // Generate a unique file name
            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(imageUrl.FileName);

            // Define the full path to save the image
            var filePath = Path.Combine(uploadsFolder, fileName);

            // Save the file to the server
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await imageUrl.CopyToAsync(fileStream);
            }

            // Set the ImageUrl property of the model to the relative path of the image
            model.ImageUrl = "/author-images/" + fileName;
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

    public ActionResult Create()
    {
        return View();
    }

    // POST: Author2Controller/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Create(Author model, IFormFile imageUrl)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        // Check if an image was uploaded
        if (imageUrl != null && imageUrl.Length > 0)
        {
            // Define the folder to store the images
            var uploadsFolder = Path.Combine(_hostEnvironment.WebRootPath, "author-images");

            // Ensure the folder exists
            if (!Directory.Exists(uploadsFolder))
            {
                Directory.CreateDirectory(uploadsFolder);
            }

            // Generate a unique file name
            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(imageUrl.FileName);

            // Define the full path to save the image
            var filePath = Path.Combine(uploadsFolder, fileName);

            // Save the file to the server
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await imageUrl.CopyToAsync(fileStream);
            }

            // Set the ImageUrl property of the model to the relative path of the image
            model.ImageUrl = "/author-images/" + fileName;
        }

        var createdSuccessfully = await authorService.CreateAuthorAsync(model);

        if (createdSuccessfully == true)
        {
            TempData["SuccessMessage"] = "Author created successfully!";
        }
        else
        {
            throw new Exception("Creating author failed, please try again later.");
        }

        return RedirectToAction("Edit", model);
    }

    public async Task<ActionResult> Delete(Guid id)
    {
        var deletedSuccessfully = await authorService.DeleteAuthorAsync(id);

        return RedirectToAction("Index");
    }
}