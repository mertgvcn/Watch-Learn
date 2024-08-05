namespace OnionArch.Application.Features.Auth.Models;
public record ChangePasswordRequest
{
    public string EncryptedPassword { get; set; }
}
