using TI_Net_2026_MyBouffe.Bend.BLL.Entities;

namespace TI_Net_2026_MyBouffe.Bend.BLL.Interfaces
{
    public interface IRecipeRepository
    {
        List<Recipe> Get();
        void Save(Recipe recipe);
    }
}
