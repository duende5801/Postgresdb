using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Postgresdb.Models;

namespace Postgresdb.Data;
public class ApiDbContext : DbContext
{
    public virtual DbSet<User> Users { get; set; }
    public virtual DbSet<Ingredient> Ingredients { get; set; }
    public virtual DbSet<Recipe> Recipes { get; set; }
    public virtual DbSet<IngredientsInRecipe> IngredientsInRecipes { get; set; }

    public ApiDbContext(DbContextOptions<ApiDbContext> options):base(options) {  }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Recipe>(entity => {
            entity.HasOne(u => u.User)
                .WithMany(r => r.Recipes)
                .HasForeignKey(u => u.UserId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("User_Fk");
        });

        modelBuilder.Entity<IngredientsInRecipe>(entity => {
            entity.HasOne(i => i.Ingredient)
                .WithOne(ir => ir.IngredientsInRecipe)
                .HasForeignKey<IngredientsInRecipe>(i_fk => i_fk.IngredientId);
            
            entity.HasOne(r => r.Recipe)
                .WithMany(i => i.IngredientsInRecipes)
                .HasForeignKey(r_fk => r_fk.RecipeId);
        });
    }
}