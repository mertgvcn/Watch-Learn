using OnionArch.Application.DTOs;

namespace OnionArch.Application.Features.Teachers.Models;
public record TeacherViewModel
{
    public required long Id { get; init; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Email { get; set; }
    public required string PhoneNumber { get; set; }
    public ICollection<CourseDTO> Courses { get; set; } = default!;
}
