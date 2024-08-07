namespace OnionArch.Application.Features.Auth.Models;
public record CheckRefreshTokenRequest
{
    public required string RefreshToken { get; set; }
}
