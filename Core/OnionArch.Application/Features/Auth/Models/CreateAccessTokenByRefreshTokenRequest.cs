namespace OnionArch.Application.Features.Auth.Models;
public record CreateAccessTokenByRefreshTokenRequest
{
    public required string RefreshToken { get; set; }
}
