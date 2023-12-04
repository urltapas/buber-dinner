using BuberDinner.Domain.Entoty;
namespace BuberDinner.Application.Common.Interfaces.Authentication;

public interface IJwtTokenGenerator
{
    string GenerateToken(User user);
}
        