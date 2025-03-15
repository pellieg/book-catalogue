using BookCatalogue.WebUI.Models;

namespace BookCatalogue.WebUI.Services;

public class AuthorService(HttpClient httpClient)
{
    // GET: Retrieve all authors
    public async Task<List<Author>?> GetAllAuthorsAsync()
    {
        var response = await httpClient.GetAsync("Author");
        
        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<List<Author>>();
        }
        
        return new List<Author>(); // Empty list if request failed
    }

    // GET: Retrieve a single author by ID
    public async Task<Author?> GetAuthorByIdAsync(Guid id)
    {
        var response = await httpClient.GetAsync($"Author/{id}");
        
        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<Author>();
        }
        
        return null; // Return null if not found
    }

    // POST: Create a new author
    public async Task<bool> CreateAuthorAsync(Author author)
    {
        var response = await httpClient.PostAsJsonAsync("Author", author);
        
        return response.IsSuccessStatusCode;
    }

    // PUT: Update an existing author
    public async Task<bool> UpdateAuthorAsync(Guid id, Author author)
    {
        var response = await httpClient.PutAsJsonAsync($"Author", author);
        
        return response.IsSuccessStatusCode;
    }

    // DELETE: Delete an author by ID
    public async Task<bool> DeleteAuthorAsync(Guid id)
    {
        var response = await httpClient.DeleteAsync($"Author/{id}");
        
        return response.IsSuccessStatusCode;
    }
}