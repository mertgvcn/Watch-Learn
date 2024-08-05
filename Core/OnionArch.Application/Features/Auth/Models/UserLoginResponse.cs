
namespace OnionArch.Application.Features.Auth.Models;

public record UserLoginResponse
{
    public required bool IsAuthenticated { get; set; }
    public required string? AccessToken { get; set; }
    public DateTime? AccessTokenExpireDate { get; set; }
    public required string? RefreshToken { get; set; }
}
