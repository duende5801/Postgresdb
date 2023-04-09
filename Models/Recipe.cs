using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Postgresdb.Models;

public class Recipe : BaseEntity
{
    public Recipe()
    {
        IngredientsInRecipes = new HashSet<IngredientsInRecipe>();
    }

    public string RecipeName { get; set; } = "";

    public int UserId { get; set; }

    // Notice the relationship needs to be declared in both directions
    // ** view notes on the Users Model
    public virtual User User { get; set; }
    public virtual ICollection<IngredientsInRecipe> IngredientsInRecipes { get; set; }
}
