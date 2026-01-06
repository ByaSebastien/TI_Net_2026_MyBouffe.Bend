using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TI_Net_2026_MyBouffe.Bend.BLL.Entities;

namespace TI_Net_2026_MyBouffe.Bend.DAL.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .ToTable("User_")
                .HasKey(u => u.Id)
                .IsClustered();
            builder
                .Property(u => u.Id)
                .ValueGeneratedOnAdd();
            builder
                .HasIndex(u => u.Username)
                .IsUnique();
            builder
                .HasMany(u => u.Recipes)
                .WithOne(r => r.User)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(r => r.UserId)
                .IsRequired();
            builder
                .HasMany(u => u.UserRecipes)
                .WithOne(ur => ur.User)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(ur => ur.UserId)
                .IsRequired();
                
        }
    }
}
