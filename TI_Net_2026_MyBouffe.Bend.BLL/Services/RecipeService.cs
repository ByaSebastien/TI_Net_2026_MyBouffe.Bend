using TI_Net_2026_MyBouffe.Bend.BLL.Entities;
using TI_Net_2026_MyBouffe.Bend.BLL.Interfaces;
using TI_Net_2026_MyBouffe.Bend.BLL.Models;
using TI_Net_2026_MyBouffe.Bend.BLL.Services.Interfaces;

namespace TI_Net_2026_MyBouffe.Bend.BLL.Services
{
    public class RecipeService(IOpenAIService openAIService) : IRecipeService
    {
        public async Task<Recipe> Save(Recipe recipe)
        {
            string nameEng = (await openAIService.GetCompletionAsync(new CompletionRequest
            {
                Model = "gpt-4o",
                Messages = [
                    new CompletionRequest.Message {
                        Role = "user",
                        Content = $"Donne moi la traduction en anglais de ce nom de recette svp : ${recipe.NameFr}",
                    },
                ],
            })).Choices.First().Message.Content;

            recipe.NameEng = nameEng;

            //Todo Save en db

            return recipe;
        }
    }
}
