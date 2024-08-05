using OnionArch.Application.Features.Auth.Models;

namespace OnionArch.Application.Interfaces.Services;
public interface IAuthenticationService
{
    Task<UserLoginResponse> LoginUserAsync(UserLoginRequest request, CancellationToken cancellationToken);
}
