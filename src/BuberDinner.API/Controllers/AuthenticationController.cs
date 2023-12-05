using BuberDinner.Application.Services.Authentication;
using BuberDinner.Contracts.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.API.Controllers;

[ApiController]
[Route("auth")]
public class AuthenticationController(IAuthenticationService authenticationService) : ControllerBase
{
    private readonly IAuthenticationService _authenticationService = authenticationService;

    [HttpPost("register")]
    public IActionResult Register(RegisterRequest request) => Ok(UserRegister(request));

    [HttpPost("login")]
    public IActionResult Login(LoginRequest request) => Ok(UserLogin(request));

    #region private methods

    private AuthenticationResponse UserRegister(RegisterRequest request)
    {
        var authResult = _authenticationService.Register(
            request.FirstName,
            request.LastName,
            request.Email,
            request.Password);

        var response = new AuthenticationResponse(
            authResult.User.Id,
            authResult.User.FirstName,
            authResult.User.LastName,
            authResult.User.Email,
            authResult.Token);
        return response;
    }

    private AuthenticationResponse UserLogin(LoginRequest request)
    {
        var authResult = _authenticationService.Login(
            request.Email,
            request.Password);

        var response = new AuthenticationResponse(
            authResult.User.Id,
            authResult.User.FirstName,
            authResult.User.LastName,
            authResult.User.Email,
            authResult.Token);
        return response;
    }

    #endregion
}