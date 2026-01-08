using Microsoft.AspNetCore.Mvc;
using TI_Net_2026_MyBouffe.Bend.API.Models;
using TI_Net_2026_MyBouffe.Bend.BLL.Entities;
using TI_Net_2026_MyBouffe.Bend.BLL.Services.Interfaces;

namespace TI_Net_2026_MyBouffe.Bend.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RecipeController(IRecipeService recipeService) : ControllerBase
    {

        [HttpGet]
        public async Task<ActionResult<List<RecipeIndexDto>>> Get()
        {
            return (await recipeService.GetAsync()).Select(r => new RecipeIndexDto(r.Id,r.NameFr,r.Calories)).ToList();
        }

        [HttpPost]
        public async Task<IActionResult> Save([FromBody] RecipeFormDto form, [FromQuery] string lang) // Utiliser DTO
        {
            var savedRecipe = await recipeService.Save( lang == "fr" ?
                new Recipe
                {
                    NameFr = form.Name,
                    DescriptionFr = form.Description,
                    StepsFr = form.Steps,
                    CompositionFr = form.Composition,
                    ServingSize = form.ServingSize,
                }
                : 
                new Recipe
                {
                    NameEng = form.Name,
                    DescriptionEng = form.Description,
                    StepsEng = form.Steps,
                    CompositionEng = form.Composition,
                    ServingSize = form.ServingSize,
                },
                lang
            );

            return Created();
        }
    }
}
