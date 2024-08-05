using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using OnionArch.Application.Interfaces.Services;
using OnionArch.Infrastructure.Token.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace OnionArch.Infrastructure.Token;
public sealed class TokenService : ITokenService
{
    private readonly IConfiguration _configuration;
    private readonly ICryptionService _cryptionService;

    public TokenService(IConfiguration configuration, ICryptionService cryptionService)
    {
        _configuration = configuration;
        _cryptionService = cryptionService;
    }

    public async Task<GenerateTokenResponse> GenerateTokenAsync(GenerateTokenRequest request, CancellationToken cancellationToken)
    {
        var accessTokenExpireDate = DateTime.UtcNow.AddHours(6);
        var refreshTokenExpireDate = DateTime.UtcNow.AddHours(24);

        var claims = await PrepareClaims(request, accessTokenExpireDate);
        var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["JWT:Secret"]));
        var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

        JwtSecurityToken jwt = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                claims: claims,
                notBefore: DateTime.UtcNow,
                expires: accessTokenExpireDate,
                signingCredentials: signingCredentials
            );

        var accessToken = new JwtSecurityTokenHandler().WriteToken(jwt);

        return await Task.FromResult(new GenerateTokenResponse
        {
            AccessToken = accessToken,
            AccessTokenExpireDate = accessTokenExpireDate,
            RefreshToken = CreateRefreshToken(),
            RefreshTokenExpireDate = refreshTokenExpireDate
        });
    }

    public ClaimsPrincipal? GetPrincipalFromExpiredAccessToken(string? accessToken)
    {
        var secret = _configuration["JWT:Secret"] ?? throw new InvalidOperationException("Secret not configured");

        var validation = new TokenValidationParameters
        {
            ValidIssuer = _configuration["JWT:ValidIssuer"],
            ValidAudience = _configuration["JWT:ValidAudience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret)),
            ValidateLifetime = false
        };

        return new JwtSecurityTokenHandler().ValidateToken(accessToken, validation, out _);
    }

    private async Task<List<Claim>> PrepareClaims(GenerateTokenRequest request, DateTime expireDate)
    {
        var encryptedUserId = await _cryptionService.Encrypt(request.UserId.ToString());

        var claims = new List<Claim>()
        {
            new Claim(ClaimTypes.NameIdentifier, encryptedUserId),
            new Claim(ClaimTypes.Role, request.Role.ToString()),
            new Claim("expireDate", expireDate.ToString()),
        };

        return claims;
    }

    private string CreateRefreshToken()
    {
        var numberByte = new byte[32];

        using var rnd = RandomNumberGenerator.Create();
        rnd.GetBytes(numberByte);

        return Convert.ToBase64String(numberByte);
    }
}
