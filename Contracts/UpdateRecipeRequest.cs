using System.ComponentModel.DataAnnotations;

namespace AlDenteAPI.Contracts;

public class UpdateRecipeRequest
{
    [Required]
    public string Name { get; set; }

}