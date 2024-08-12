using OnionArch.Application.DTOs;

namespace OnionArch.Application.Features.Courses.Models;
public record CourseViewModel
{
    public required long Id { get; init; }
    public required string Title { get; set; }
    public required string ShortDescription { get; set; }
    public required string Description { get; set; }
    public TimeSpan TotalLessonDuration { get; set; }
    public required double Price { get; set; }
    public TeacherDTO Teacher { get; set; } = default!;
    public ICollection<LessonDTO> Lessons { get; set; } = default!;
    public ICollection<StudentDTO> Students { get; set; } = default!;
}
