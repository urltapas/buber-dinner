using BuberDinner.Application.Coomon.Interfaces.Services;

namespace BuberDinner.Infra.Services;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}
