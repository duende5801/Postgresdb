using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Postgresdb.Models;

public class BaseEntity
{
    public int Id { get; set; }

    public DateTime DateAdded { get; set; }

    public DateTime DateUpdated { get; set; }

}
