using BuberDinner.Application.Errors;
using Microsoft.AspNetCore.Diagnostics;

namespace BuberDinner.API.Controllers;

public class ErrorsController : ControllerBase
{
    [Route("/error")]
    public IActionResult Error()
    {
        var exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;
        var (statusCode, message) = exception switch
        {
            IServiceException serviceException => ((int)serviceException.StatusCode, serviceException.ErrorMessage),
            _ => (StatusCodes.Status500InternalServerError, "An error occurred while processing your request")
        };

        return Problem(title: message, statusCode: statusCode);
    }
}