using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Postgresdb.Models;
using Postgresdb.Services;
using Postgresdb.Services.Interfaces;

namespace Postgresdb.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RecipeController : ControllerBase
    {
        private readonly RecipeService _data;
        public RecipeController(RecipeService dataFromService)
        {
            _data = dataFromService;
        }

        [HttpGet]
        [Route("getUserRecipies")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(ValidationProblemDetails))]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized, Type = typeof(ValidationProblemDetails))]
        [ProducesResponseType((int)HttpStatusCode.NotFound, Type = typeof(ValidationProblemDetails))]
        public IEnumerable<Recipe> GetAllRecipiesForUser(int userId)
        {
            return _data.GetAllRecipiesForUser(userId);
        }

        [HttpGet]
        [Route("getUserRecipies/{id}")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(ValidationProblemDetails))]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized, Type = typeof(ValidationProblemDetails))]
        [ProducesResponseType((int)HttpStatusCode.NotFound, Type = typeof(ValidationProblemDetails))]
        public DefinedRecipe GetRecipe(int id)
        {
            return _data.GetRecipe(id);
        }

        [HttpPost]
        [Route("recipies")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(ValidationProblemDetails))]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized, Type = typeof(ValidationProblemDetails))]
        [ProducesResponseType((int)HttpStatusCode.NotFound, Type = typeof(ValidationProblemDetails))]
        public bool PostRecipe([FromBody] Recipe request)
        {
            // the return type will most likely be something like a Task<ActionResult<bool>>
            // gotta probably make things async too. 
            return _data.PostRecipe(request);
        }
    }
}