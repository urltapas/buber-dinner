﻿using System.Security.Claims;
using BuberDinner.Application.Coomon.Interfaces.Authentication;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using BuberDinner.Application.Coomon.Interfaces.Services;
using Microsoft.Extensions.Options;

namespace BuberDinner.Infra.Authentication;

public class JwtTokenGenerator(IDateTimeProvider dateTimeProvider, IOptions<JwtSettings> jwtSettings) : IJwtTokenGenerator
{
    private readonly IDateTimeProvider _dateTimeProvider = dateTimeProvider;
    private readonly JwtSettings _jwtSettings = jwtSettings.Value;

    public string GenerateToken(Guid userId, string firstName, string lastName)
    {
        var signingCredentials = new SigningCredentials(
            key: new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.SecrectKey)),
            algorithm: SecurityAlgorithms.HmacSha256);

        var claims = new[] {
            new Claim(JwtRegisteredClaimNames.Sub, userId.ToString()),
            new Claim(JwtRegisteredClaimNames.GivenName, firstName),
            new Claim(JwtRegisteredClaimNames.FamilyName, lastName),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        };

        var securityToken = new JwtSecurityToken(
            issuer: _jwtSettings.Issuer,
            claims: claims,
            audience: _jwtSettings.Audience,
            signingCredentials: signingCredentials,
            expires: _dateTimeProvider.UtcNow.AddHours(_jwtSettings.ExpiryMinutes)
            );

        return new JwtSecurityTokenHandler().WriteToken(securityToken);
    }
}
