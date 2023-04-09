using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Postgresdb.Services.Interfaces;

public class DefinedRecipe
{
    public string Name { get; set; }

    public List<IngredientList> Ingredients  { get; set; }
}