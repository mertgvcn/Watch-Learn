using OnionArch.Infrastructure.Token.Models;
using System.Security.Claims;

namespace OnionArch.Application.Interfaces.Services;
public interface ITokenService
{
    Task<GenerateTokenResponse> GenerateTokenAsync(GenerateTokenRequest request, CancellationToken cancellationToken);
    ClaimsPrincipal? GetPrincipalFromExpiredAccessToken(string? accessToken);
}
