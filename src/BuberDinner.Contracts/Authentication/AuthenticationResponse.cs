namespace BuberDinner.Contracts.Authentication;

public record AuthenticationResponse(
    Guid Id,
    string FristName,
    string LastName,
    string Email,
    string Token);