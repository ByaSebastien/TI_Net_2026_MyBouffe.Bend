using Microsoft.EntityFrameworkCore;
using TI_Net_2026_MyBouffe.Bend.BLL.Entities;

namespace TI_Net_2026_MyBouffe.Bend.DAL.Contexts
{
    public class MyBouffeContext: DbContext
    {
        public DbSet<User> Users => Set<User>();
        public DbSet<Recipe> Recipes => Set<Recipe>();
        public DbSet<UserRecipe> UserRecipes => Set<UserRecipe>();

        public MyBouffeContext(DbContextOptions<MyBouffeContext> options) : base(options){}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MyBouffeContext).Assembly);
        }
    }
}
