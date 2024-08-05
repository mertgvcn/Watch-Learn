namespace OnionArch.Infrastructure.Token.Models;
public record GenerateTokenRequest
{
    public required string UserId { get; set; }
}
