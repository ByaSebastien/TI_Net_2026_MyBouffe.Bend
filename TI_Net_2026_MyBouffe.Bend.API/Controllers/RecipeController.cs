using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TI_Net_2026_MyBouffe.Bend.API.Models;
using TI_Net_2026_MyBouffe.Bend.BLL.Entities;
using TI_Net_2026_MyBouffe.Bend.BLL.Services.Interfaces;

namespace TI_Net_2026_MyBouffe.Bend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeController(IRecipeService recipeService) : ControllerBase
    {

        [HttpPost]
        public async Task<ActionResult<Recipe>> Save([FromBody] RecipeFormDto form) // Utiliser DTO
        {
            var savedRecipe = await recipeService.Save(new Recipe { NameFr = form.name });

            return Ok(savedRecipe);
        }
    }
}
