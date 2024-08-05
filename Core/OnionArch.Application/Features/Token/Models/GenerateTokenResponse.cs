namespace OnionArch.Infrastructure.Token.Models;
public record GenerateTokenResponse
{
    public required string AccessToken { get; set; }
    public required DateTime AccessTokenExpireDate { get; set; }
    public required string RefreshToken { get; set; }
    public required DateTime RefreshTokenExpireDate { get; set; }
}
