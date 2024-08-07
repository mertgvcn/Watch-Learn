
namespace OnionArch.Application.Features.Auth.Models;

public record UserLoginResponse
{
    public required string? AccessToken { get; set; }
    public required DateTime AccessTokenExpireDate { get; set; }
    public required string? RefreshToken { get; set; }
    public required DateTime RefreshTokenExpireDate { get; set; }
}
