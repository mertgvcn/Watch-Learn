namespace OnionArch.Application.Features.Auth.Models;
public record CreateAccessTokenByRefreshTokenRequest
{
    public required string AccessToken { get; set; }
    public required string RefreshToken { get; set; }
}
