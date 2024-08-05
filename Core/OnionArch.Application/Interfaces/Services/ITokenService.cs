using OnionArch.Infrastructure.Token.Models;

namespace OnionArch.Application.Interfaces.Services;
public interface ITokenService
{
    Task<GenerateTokenResponse> GenerateTokenAsync(GenerateTokenRequest request);
}
