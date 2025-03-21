using System.ComponentModel.DataAnnotations;

namespace BookCatalogue.Core.Models;

public class Author
{
    public Guid Id { get; set; } = Guid.CreateVersion7(DateTimeOffset.UtcNow);
    [MaxLength(250)]
    public string FirstName { get; set; } = string.Empty;
    [MaxLength(250)]
    public string LastName { get; set; } = string.Empty;
}