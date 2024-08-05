namespace OnionArch.Application.Features.Auth.Models;
public record UserLoginRequest
{
    public required string Email { get; set; }
    public required string EncryptedPassword { get; set; }
}
