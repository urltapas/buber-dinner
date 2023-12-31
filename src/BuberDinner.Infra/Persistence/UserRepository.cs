﻿using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.Entities;

namespace BuberDinner.Infra.Persistence;

public class UserRepository : IUserRepository
{
    private static readonly List<User> _users = new();

    public void AddUser(User user)
    {
        _users.Add(user);
    }

    public User? GetUserByEmail(string email)
    {
        return _users.SingleOrDefault(x => x.Email == email);
    }
}