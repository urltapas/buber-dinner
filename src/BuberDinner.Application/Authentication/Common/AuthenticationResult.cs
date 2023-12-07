using BuberDinner.Domain.Entities;
using MediatR;

namespace BuberDinner.Application.Authentication.Common;

public record AuthenticationResult(User User, string Token);