using BuberDinner.Application.Common.Interfaces.Authentication;
using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Application.Errors;
using BuberDinner.Application.Services.Authentication.Common;
using BuberDinner.Domain.Entities;

namespace BuberDinner.Application.Services.Authentication.Queries;

public class AuthenticationQueryService(IJwtTokenGenerator tokenGenerator, IUserRepository userRepository) : IAuthenticationQueryService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator = tokenGenerator;
    private readonly IUserRepository _userRepository = userRepository;

    public AuthenticationResult Login(string email, string password)
    {
        // Validate the user exists
        if (_userRepository.GetUserByEmail(email) is not User user)
            throw new EmailGivenNotFoundException();


        // Validate the password is correct
        if (user.Password != password) throw new Errors.InvalidPasswordException();


        // Create JWT token
        var token = _jwtTokenGenerator.GenerateToken(user);
        return new AuthenticationResult(user, token);
    }
}