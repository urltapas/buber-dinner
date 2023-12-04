using BuberDinner.Domain.Entoty;

namespace BuberDinner.Application.Common.Interfaces.Persistence;

public interface IUserRepository
{
    User? GetUserByEmail(string email);
    void AddUser(User user);
}
