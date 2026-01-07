using System.Text.Json;

namespace TI_Net_2026_MyBouffe.Bend.BLL.Entities
{
    public class Recipe
    {
        public long Id { get; set; }
        public string NameFr { get; set; } = null!;
        public string NameEng { get; set; } = null!;
        public string DescriptionFr { get; set; } = null!;
        public string DescriptionEng { get; set; } = null!;
        public string StepsFr { get; set; } = null!;
        public string StepsEng { get; set; } = null!;
        public string CompositionFr { get; set; } = null!;
        public string CompositionEng { get; set; } = null!;
        public int Calories { get; set; }
        public int ServingSize { get; set; }
        public string Image { get; set; } = null!;
        public string AudioFr { get; set; } = null!;
        public string AudioEng { get; set; } = null!;
        public long UserId { get; set; }
        
        public User User { get; set; } = null!;
        public IEnumerable<UserRecipe> UserRecipes { get; set; } = [];

        public override string ToString()
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                IgnoreReadOnlyProperties = false
            };

            return JsonSerializer.Serialize(new
            {
                Id,
                NameFr,
                NameEng,
                DescriptionFr,
                DescriptionEng,
                StepsFr,
                StepsEng,
                CompositionFr,
                CompositionEng,
                Calories,
                ServingSize,
                UserId
            }, options);
        }
    }
}
