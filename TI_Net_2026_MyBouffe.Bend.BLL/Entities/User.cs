namespace TI_Net_2026_MyBouffe.Bend.BLL.Entities
{
    public class User
    {
        public long Id { get; set; }
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public int Weight { get; set; }
        public int Height { get; set; }
        public double BMI { get; set; }

        public IEnumerable<Recipe> Recipes { get; set; } = [];
        public IEnumerable<UserRecipe> UserRecipes { get; set; } = [];
    }
}
