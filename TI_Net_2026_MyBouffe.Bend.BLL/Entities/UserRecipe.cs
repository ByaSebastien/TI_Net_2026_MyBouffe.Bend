namespace TI_Net_2026_MyBouffe.Bend.BLL.Entities
{
    public class UserRecipe
    {
        public long Id { get; set; }
        public DateTime Date { get; set; }
        public long UserId { get; set; }
        public long RecipeId { get; set; }

        public User User { get; set; } = null!;
        public Recipe Recipe { get; set; } = null!;
    }
}
