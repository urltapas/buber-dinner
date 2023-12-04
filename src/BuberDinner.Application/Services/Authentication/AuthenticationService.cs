using BuberDinner.Application.Common.Interfaces.Authentication;
using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.Entoty;

namespace BuberDinner.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public AuthenticationResult Register(string firstName, string lastName, string email, string password)
    {
        // Check if user already exists
        if(_userRepository.GetUserByEmail(email) is not null)
        {
            throw new Exception("User with given email already exists.");
        }
        
        var user = new User{
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            Password = password
        };

        // Create user (generate unique ID) & Persist user
        _userRepository.AddUser(user);
        
        // Create JWT token
        var token = _jwtTokenGenerator.GenerateToken(user);
        return new AuthenticationResult(user, token);
    }

    public AuthenticationResult Login(string email, string password)
    {
        // Validate the user exists
        if(_userRepository.GetUserByEmail(email) is not User user)
            throw new Exception("User with given email does not exist.");

        if(user.Password != password) throw new Exception("Invalid password.");
        // Validate the password is correct


        // Create JWT token
        var token = _jwtTokenGenerator.GenerateToken(user);
        return new AuthenticationResult(user, token);
    }
}
