using OnionArch.Application.InfrastructureModels.Models;
using OnionArch.Domain.Entities;

namespace OnionArch.Application.Interfaces.Services;
public interface ITokenService
{
    Task<GenerateTokenResponse> GenerateTokenAsync(User user, CancellationToken cancellationToken);
    //ClaimsPrincipal? GetPrincipalFromExpiredAccessToken(string? accessToken);
}
