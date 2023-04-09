using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Postgresdb.Data;
using Postgresdb.Models;
using Postgresdb.Services.Interfaces;

namespace Postgresdb.Services;

public class RecipeService : ControllerBase
{
    public readonly ApiDbContext _context;

    public RecipeService(ApiDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Recipe> GetAllRecipiesForUser(int userId)
    {
        return _context.Recipes.Where(row => row.UserId == userId);
    }

    public DefinedRecipe GetRecipe(int recipeId)
    {
        var recipe = _context.Recipes.SingleOrDefault(row => row.Id == recipeId);
        var data = _context.IngredientsInRecipes.Where(row => row.RecipeId == recipeId);

        var definedRecipe = new DefinedRecipe();
        List<IngredientList> ingreidentList = new List<IngredientList>();

        foreach (var ingredient in data)
        {
            var ingredientInfo = _context.Ingredients.SingleOrDefault<Ingredient>(row => row.Id == ingredient.IngredientId);
            var ingredientName = ingredientInfo.IngredientName;
            
            var foo = new IngredientList();
            foo.IngredientName = ingredientName;
            foo.UnitSize = ingredient.UnitSize;

            ingreidentList.Add(foo);
        }
        
        definedRecipe.Name = recipe.RecipeName;
        definedRecipe.Ingredients = ingreidentList ?? new List<IngredientList>();

        return definedRecipe;
    }

    public bool PostRecipe(Recipe recipeToAdd)
    {
        // ** DISCLAIMER: this input/output might not be exactly what
        // the ui will send to this endpoint. this is a generic example.
        // TODO: Save to database actions here
        // Possibly add some dto's? but that's intirely up to you.
        return true;
    }
}