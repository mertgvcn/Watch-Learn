using OnionArch.Application.DTOs;

namespace OnionArch.Application.Features.Courses.Models;
public record CourseViewModel
{
    public required long Id { get; init; }
    public required string Title { get; set; }
    public required string Description { get; set; }
    public TeacherDTO Teacher { get; set; } = default!;
}
