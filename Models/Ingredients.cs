using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Postgresdb.Models;

// Needs to have a standard unit size for caluclations
// ie. Everything is nutient value is based off 1 grams.
// this way when the recipe dictates the units size there
// is an easy calculation to make.
public class Ingredient : BaseEntity
{
    public string IngredientName { get; set; } = "";
    public int Sodium { get; set; }
    public int Calories { get; set; }
    public int VitaminA { get; set; }
    public int VitaminB { get; set; }

    public virtual IngredientsInRecipe IngredientsInRecipe { get; set; }
}