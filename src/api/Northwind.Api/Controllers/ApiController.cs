using System;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Northwind.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    [SwaggerResponse((int)HttpStatusCode.InternalServerError, "Server error", type: typeof(ProblemDetails))]
    public abstract class ApiController : ControllerBase
    {
    }
}
