namespace BookCatalogue.Core.Models;
using System.ComponentModel.DataAnnotations;

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