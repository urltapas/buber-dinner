namespace BuberDinner.Application.Authentication.Queries;

public record LoginQuery(string Email, string Password) : IRequest<AuthenticationResult>;