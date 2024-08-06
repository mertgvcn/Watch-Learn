using OnionArch.Application.Features.Auth.Models;
using OnionArch.Application.InfrastructureModels.Models;

namespace OnionArch.Application.Interfaces.Services;
public interface IAuthenticationService
{
    Task<UserLoginResponse> LoginUserAsync(UserLoginRequest request, CancellationToken cancellationToken);
    Task RegisterUserAsync(UserRegisterRequest request, CancellationToken cancellationToken);
    Task<GenerateTokenResponse> CreateAccessTokenByRefreshTokenAsync(CreateAccessTokenByRefreshTokenRequest request, CancellationToken cancellationToken);
    Task RevokeRefreshTokenAsync(CancellationToken cancellationToken);
}
