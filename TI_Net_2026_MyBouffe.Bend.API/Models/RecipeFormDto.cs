using System.ComponentModel.DataAnnotations;

namespace TI_Net_2026_MyBouffe.Bend.API.Models
{
    public record RecipeFormDto(
        [Required]
        string name
    );
}
