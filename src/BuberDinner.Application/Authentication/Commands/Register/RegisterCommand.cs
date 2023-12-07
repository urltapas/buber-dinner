﻿using BuberDinner.Application.Authentication.Common;
using MediatR;

namespace BuberDinner.Application;

public record RegisterCommand(
    string FirstName,
    string LastName,
    string Email,
    string Password) : IRequest<AuthenticationResult>;