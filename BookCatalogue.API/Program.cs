using BookCatalogue.API.Database;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using Npgsql.EntityFrameworkCore.PostgreSQL;

var builder = WebApplication.CreateBuilder(args);

//builder.Configuration.AddUserSecrets<Program>();

// Add services to the container.
builder.Services.AddDbContext<BookCatalogueContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("PostgresConnectionString")));

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

using (var serviceScope = app.Services
           .GetRequiredService<IServiceScopeFactory>()
           .CreateScope())
{
    using (var context = serviceScope.ServiceProvider.GetService<BookCatalogueContext>())
    {
        if (context == null) 
            throw new NullReferenceException("Book database context is null");
        context.Database.Migrate();
    }
}

app.Run();