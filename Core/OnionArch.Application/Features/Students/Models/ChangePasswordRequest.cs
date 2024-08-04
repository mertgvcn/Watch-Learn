namespace OnionArch.Application.Features.Students.Models;
public record ChangePasswordRequest
{
    public string EncryptedPassword { get; set; }
}
