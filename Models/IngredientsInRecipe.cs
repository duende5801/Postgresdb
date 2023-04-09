using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Postgresdb.Models;

public class IngredientsInRecipe : BaseEntity
{
    public int IngredientId { get; set; }

    public int RecipeId { get; set; }

    public int UnitSize { get; set; }

    // This is a 1 to 1 connection. We are calling 1 Ingredient per
    // `ingredinets_in_recipe: id` property.
    public virtual Ingredient Ingredient { get; set; }

    // This is a 1 to many connection (hence the collection).
    // We'll be using the `recipe_id` to filter a collection
    // of ingredients. Since we have a 1 to many relationship
    // we declare `IngredientsInRecipe`as an ICollection 
    //on the `RecipeModel`.
    public virtual Recipe Recipe { get; set; }
}