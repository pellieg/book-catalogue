using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace BookCatalogue.API.Database;

public class BookCatalogueContext(DbContextOptions<BookCatalogueContext> options) : DbContext(options)
{
    public DbSet<Book> Books { get; set; }
    public DbSet<Author> Authors { get; set; }
}

public class Book
{
    public Guid Id { get; set; } = Guid.CreateVersion7(DateTimeOffset.UtcNow);
    
    [MaxLength(250)]
    [Required]
    public string Title { get; set; } = string.Empty;
    
    [MaxLength(1000)]
    public string? Description { get; set; } = string.Empty;
    
    [MaxLength(250)]
    public string? ImageUrl { get; set; } = string.Empty;
    
    public Author Author { get; set; } = new();
}

public class Author
{
    public Guid Id { get; set; } = Guid.CreateVersion7(DateTimeOffset.UtcNow);
    [MaxLength(250)]
    public string FirstName { get; set; } = string.Empty;
    [MaxLength(250)]
    public string LastName { get; set; } = string.Empty;
}