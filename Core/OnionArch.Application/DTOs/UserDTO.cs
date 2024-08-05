using OnionArch.Domain.Enumerators;

namespace OnionArch.Application.DTOs;
public record UserDTO
{
    public long Id { get; init; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Email { get; set; }
    public required string PhoneNumber { get; set; }
    public required Roles Role { get; set; } = Roles.Student;
}
