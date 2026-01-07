using System.ComponentModel.DataAnnotations;

namespace TI_Net_2026_MyBouffe.Bend.API.Models
{
    public record RecipeFormDto(
        [Required]
        string Name,
        [Required]
        string Description,
        [Required]
        string Steps,
        [Required]
        string Composition,
        [Required]
        [Range(1,int.MaxValue)]
        int ServingSize
    );
}
