using System.ComponentModel.DataAnnotations;
using BookCatalogue.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace BookCatalogue.API.Database;

public class BookCatalogueContext(DbContextOptions<BookCatalogueContext> options) : DbContext(options)
{
    public DbSet<Book> Books { get; set; }
    public DbSet<Author> Authors { get; set; }
}