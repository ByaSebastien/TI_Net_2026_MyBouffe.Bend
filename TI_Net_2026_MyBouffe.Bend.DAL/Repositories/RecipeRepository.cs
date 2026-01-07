using TI_Net_2026_MyBouffe.Bend.BLL.Entities;
using TI_Net_2026_MyBouffe.Bend.BLL.Interfaces;
using TI_Net_2026_MyBouffe.Bend.DAL.Contexts;

namespace TI_Net_2026_MyBouffe.Bend.DAL.Repositories
{
    public class RecipeRepository(MyBouffeContext context) : IRecipeRepository
    {
        public void Save(Recipe recipe)
        {
            context.Recipes.Add(recipe);
            context.SaveChanges();
        }
    }
}
