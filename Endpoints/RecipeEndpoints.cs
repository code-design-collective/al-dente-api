using Microsoft.EntityFrameworkCore;
using AlDenteAPI.Contracts;
using AlDenteAPI.Database;
using AlDenteAPI.Models;

namespace AlDenteAPI.Endpoints;

public static class RecipeEndpoints
{
    public static void MapRecipeEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapPost("recipes", async (
            CreateRecipeRequest request,
            ApplicationDbContext context,
            CancellationToken ct) =>
        {
            var recipe = new Recipe
            {
                Name = request.Name,
                Price = request.Price
            };

            context.Add(recipe);

            await context.SaveChangesAsync(ct);

            return Results.Ok(recipe);
        });

        app.MapGet("recipes", async (
            ApplicationDbContext context,
            CancellationToken ct,
            int page = 1,
            int pageSize = 10) =>
        {
            var recipes = await context.Recipes
                .AsNoTracking()
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync(ct);

            return Results.Ok(recipes);
        });

        app.MapGet("recipes/{id}", async (
            int id,
            ApplicationDbContext context,
            CancellationToken ct) =>
        {
            var recipe = await context.Recipes
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id, ct);

            return recipe is null ? Results.NotFound() : Results.Ok(recipe);
        });

        app.MapPut("recipes/{id}", async (
            int id,
            UpdateRecipeRequest request,
            ApplicationDbContext context,
            CancellationToken ct) =>
        {
            var recipe = await context.Recipes
                .FirstOrDefaultAsync(p => p.Id == id, ct);

            if (recipe is null)
            {
                return Results.NotFound();
            }

            recipe.Name = request.Name;
            recipe.Price = request.Price;

            await context.SaveChangesAsync(ct);

            return Results.NoContent();
        });

        app.MapDelete("recipes/{id}", async (
            int id,
            ApplicationDbContext context,
            CancellationToken ct) =>
        {
            var recipe = await context.Recipes
                .FirstOrDefaultAsync(p => p.Id == id, ct);

            if (recipe is null)
            {
                return Results.NotFound();
            }

            context.Remove(recipe);

            await context.SaveChangesAsync(ct);

            return Results.NoContent();
        });
    }
}
