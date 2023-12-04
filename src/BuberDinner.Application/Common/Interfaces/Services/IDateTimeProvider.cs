namespace BuberDinner.Application.Coomon.Interfaces.Services;

public interface IDateTimeProvider
{
    DateTime UtcNow { get; }
}
