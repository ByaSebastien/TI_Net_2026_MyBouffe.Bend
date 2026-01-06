using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TI_Net_2026_MyBouffe.Bend.BLL.Entities;

namespace TI_Net_2026_MyBouffe.Bend.DAL.Configurations
{
    public class RecipeConfiguration : IEntityTypeConfiguration<Recipe>
    {
        public void Configure(EntityTypeBuilder<Recipe> builder)
        {
            builder
                .ToTable("Recipe")
                .HasKey(r => r.Id)
                .IsClustered();
            builder
                .Property(r => r.Id)
                .ValueGeneratedOnAdd();

            builder
                .HasOne(r => r.User)
                .WithMany(u => u.Recipes)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(r => r.UserId)
                .IsRequired();

            builder
                .HasMany(r => r.UserRecipes)
                .WithOne(ur => ur.Recipe)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(ur => ur.RecipeId)
                .IsRequired();

        }
    }
}
