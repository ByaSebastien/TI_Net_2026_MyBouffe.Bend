using TI_Net_2026_MyBouffe.Bend.BLL.Entities;

namespace TI_Net_2026_MyBouffe.Bend.BLL.Services.Interfaces
{
    public interface IRecipeService
    {
        public Task<Recipe> Save(Recipe recipe);
    }
}
