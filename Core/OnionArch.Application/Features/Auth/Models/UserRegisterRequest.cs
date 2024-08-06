namespace OnionArch.Application.Features.Auth.Models;
public record UserRegisterRequest
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Email { get; set; }
    public required string PhoneNumber { get; set; }
    public required string EncryptedPassword { get; set; }

}
