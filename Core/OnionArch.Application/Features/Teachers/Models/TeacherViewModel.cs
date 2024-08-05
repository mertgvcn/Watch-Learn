namespace OnionArch.Application.Features.Teachers.Models;
public record TeacherViewModel
{
    public required long Id { get; init; }
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string PhoneNumber { get; set; } = default!;
}
