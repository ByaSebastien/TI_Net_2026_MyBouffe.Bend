using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TI_Net_2026_MyBouffe.Bend.BLL.Entities;

namespace TI_Net_2026_MyBouffe.Bend.DAL.Configurations
{
    public class UserRecipeConfiguration : IEntityTypeConfiguration<UserRecipe>
    {
        public void Configure(EntityTypeBuilder<UserRecipe> builder)
        {
            builder
                .ToTable("User_Recipe")
                .HasKey(ur => ur.Id);
            builder
                .Property(ur => ur.Id)
                .ValueGeneratedOnAdd();

            builder
                .HasOne(ur => ur.User)
                .WithMany(u => u.UserRecipes)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(ur => ur.UserId)
                .IsRequired();

            builder
                .HasOne(ur => ur.Recipe)
                .WithMany(r =>  r.UserRecipes)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(ur => ur.RecipeId)
                .IsRequired();
        }
    }
}
