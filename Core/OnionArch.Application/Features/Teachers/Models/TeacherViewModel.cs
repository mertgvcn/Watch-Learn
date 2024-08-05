using OnionArch.Application.DTOs;

namespace OnionArch.Application.Features.Teachers.Models;
public record TeacherViewModel
{
    public long Id { get; init; }
    public UserDTO User { get; set; } = default!;
    public ICollection<CourseDTO> Courses { get; set; } = default!;
}
