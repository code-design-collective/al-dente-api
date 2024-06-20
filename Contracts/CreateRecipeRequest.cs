using System.ComponentModel.DataAnnotations;

namespace AlDenteAPI.Contracts;

public class CreateRecipeRequest
{
    [Required]
    public string Name { get; set; }

}