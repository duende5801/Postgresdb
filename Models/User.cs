using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Postgresdb.Models;

public class User : BaseEntity
{
    // necessary constructor for the table
    public User()
    {
        Recipes = new HashSet<Recipe>();
    }

    public string Username { get; set; } = "";
    public string Email { get; set; } = "";
    public string FirstName { get; set; } = "";
    public string LastName { get; set; } = "";
    public string Password { get; set; } = "";

    // This is telling EntityFramework about the releationship between the two tables
    // ie. users table is going to have a relationship with the recipe table
    // saying which recipe belonging to which particular user.
    public virtual ICollection<Recipe> Recipes { get; set; }
}
