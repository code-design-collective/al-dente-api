using System.ComponentModel.DataAnnotations;

namespace AlDenteAPI.Contracts;

public class CreateRecipeRequest
{
    [Required]
    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;
    public string Ingredients { get; set; } = string.Empty;
    public string Instructions { get; set; } = string.Empty;
}