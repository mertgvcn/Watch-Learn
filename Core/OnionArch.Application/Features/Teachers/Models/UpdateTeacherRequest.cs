namespace OnionArch.Application.Features.Teachers.Models;
public record UpdateTeacherRequest
{
    public required long Id { get; init; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
}
