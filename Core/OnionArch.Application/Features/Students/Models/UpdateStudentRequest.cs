namespace OnionArch.Application.Features.Students.Models;
public record UpdateStudentRequest
{
    public required long Id { get; init; }
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string PhoneNumber { get; set; } = default!;
}
