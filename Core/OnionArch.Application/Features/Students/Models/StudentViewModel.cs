using OnionArch.Application.DTOs;

namespace OnionArch.Application.Features.Students.Models;
public record StudentViewModel
{
    public required long Id { get; init; }
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string PhoneNumber { get; set; } = default!;
    public ICollection<CourseDTO> Courses { get; set; } = default!;
}
