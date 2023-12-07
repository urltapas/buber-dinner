using BuberDinner.Application.Authentication.Commands.Register;

namespace BuberDinner.API.Controllers;

[ApiController]
[Route("auth")]
public class AuthenticationController(ISender mediator) : ControllerBase
{
    private readonly ISender _mediator = mediator;

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        var command = new RegisterCommand(
            request.FirstName,
            request.LastName,
            request.Email,
            request.Password);

        var authResult = await _mediator.Send(command);
        return Ok(authResult);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var authResult = await _mediator.Send(new LoginQuery(request.Email, request.Password));
        var response = new AuthenticationResult(
            authResult.User,
            authResult.Token);

        return Ok(response);
    }
}