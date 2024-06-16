using AlDenteAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using AlDenteAPI.Data;

public class RecipeService
{
    private readonly RecipeContext _context;

    public RecipeService(RecipeContext context)
    {
        _context = context;
    }

    public async Task<List<Recipe>> GetRecipesAsync()
    {
        return await _context.Recipes.ToListAsync();
    }

    public async Task UpdateRecipeAsync(Recipe recipe)
    {
        _context.Entry(recipe).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    // Add other methods as needed...
}