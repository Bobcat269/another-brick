using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PantryWebApp.Models;

namespace PantryWebApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        //Ingredients
        public DbSet<PantryWebApp.Models.Ingredient> Ingredient { get; set; } = default!;

        //Recipes
        public DbSet<PantryWebApp.Models.Recipe> Recipe { get; set; } = default!;
        
        // Bridge Table
        //public DbSet<RecipeIngredient> RecipeIngredients { get; set; } = default!;


        //Ran out of time on managing the bridge table relationship,

        //This is where we hand the M:N (N:M?) relationship via the OnModelCreating method
        //Source: https://learn.microsoft.com/en-us/ef/core/modeling/

        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    base.OnModelCreating(builder);//Constructor?

        //    //define the relationship
        //    //Make the Key
        //    builder.Entity<RecipeIngredient>()
        //        .HasKey(ri => new { ri.RecipeId, ri.IngredientId }); //Uses both Foreign keys as a Composite key

        //    builder.Entity<RecipeIngredient>()
        //        .HasOne(ri => ri.Recipe)
        //        .WithMany(r => r.RecipeIngredients)
        //        .HasForeignKey(ri => ri.RecipeId)
        //        .OnDelete(DeleteBehavior.Cascade); //Cascade on delete

        //    builder.Entity<RecipeIngredient>()
        //        .HasOne(ri => ri.Ingredient)
        //        .WithMany(i => i.RecipeIngredients)
        //        .HasForeignKey(ri => ri.IngredientId)
        //        .OnDelete(DeleteBehavior.Cascade); //Cascade on delete


        //}
    }
}
