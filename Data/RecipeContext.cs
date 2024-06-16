using Microsoft.EntityFrameworkCore;
using AlDenteAPI.Models;

namespace AlDenteAPI.Data
{
    public class RecipeContext : DbContext
    {
        public RecipeContext(DbContextOptions<RecipeContext> options)
            : base(options)
        {
        }

        public DbSet<Recipe> Recipes { get; set; }
    }
}