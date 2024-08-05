using OnionArch.Domain.Enumerators;

namespace OnionArch.Application.Features.Users.Models;
public record UserViewModel
{
    public required long Id { get; init; }
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string PhoneNumber { get; set; } = default!;
    public Roles Role { get; set; } = default!;
}
