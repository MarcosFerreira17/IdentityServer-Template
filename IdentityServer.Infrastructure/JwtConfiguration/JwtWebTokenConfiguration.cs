using System.Globalization;
using System.Net.Mime;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using IdentityServer.Domain.Dtos;
using IdentityServer.Domain.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using IdentityServer.Infrastructure.Repositories.Interfaces;

namespace IdentityServer.Infrastructure.JwtConfiguration;

public class JwtWebTokenConfiguration
{
    protected readonly IConfiguration _configuration;
    protected readonly IAuthRepository _authRepository;
    public JwtWebTokenConfiguration(IConfiguration configuration, IAuthRepository authRepository)
    {
        _configuration = configuration;
        _authRepository = authRepository;
    }

    private List<Claim> GenerateClaims(User user)
    {
        var role = _authRepository.GetRole(user.RoleId);
        return new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Username),
            new Claim(ClaimTypes.Role, role.Result.Name),
        };
    }
    public string CreateToken(User user)
    {
        string issuer = _configuration.GetSection("JwtSettings:Issuer").Value;
        if (string.IsNullOrEmpty(issuer))
        {
            throw new InvalidOperationException("Issuer not found in configuration");
        }

        string audience = _configuration.GetSection("JwtSettings:Audience").Value;
        if (string.IsNullOrEmpty(audience))
        {
            throw new InvalidOperationException("Audience not found in configuration");
        }

        string expiryTimeTokenString = _configuration.GetSection("JwtSettings:ExpiryInMinutes").Value;
        if (!double.TryParse(expiryTimeTokenString, out double expiryTimeToken))
        {
            throw new InvalidOperationException("Invalid expiry time token in configuration");
        }

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("JwtSettings:Key").Value));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

        var claims = GenerateClaims(user);

        var token = new JwtSecurityToken(
            issuer: issuer,
            audience: audience,
            claims: claims,
            expires: DateTime.Now.AddMinutes(expiryTimeToken),
            signingCredentials: creds
        );

        var tokenHandler = new JwtSecurityTokenHandler();
        return tokenHandler.WriteToken(token);
    }
}
