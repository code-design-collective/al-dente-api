using Microsoft.EntityFrameworkCore;
using AlDenteAPI.Models;

namespace AlDenteAPI.Database;

public sealed class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Recipe> Recipes { get; set; }
}