using BuberDinner.Application.Authentication.Commands.Register;
using MapsterMapper;

namespace BuberDinner.API.Controllers;

[ApiController]
[Route("auth")]
public class AuthenticationController(ISender mediator, IMapper mapper) : ControllerBase
{
    private readonly ISender _mediator = mediator;
    private readonly IMapper _mapper = mapper;

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        var command = _mapper.Map<RegisterCommand>(request);
        var authResult = await _mediator.Send(command);
        
        return Ok(_mapper.Map<AuthenticationResponse>(authResult));
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var authResult = await _mediator.Send(new LoginQuery(request.Email, request.Password));
        var response = new AuthenticationResult(authResult.User, authResult.Token);

        return Ok(_mapper.Map<AuthenticationResponse>(response));
    }
}