using OnionArch.Application.DTOs;

namespace OnionArch.Application.Features.Courses.Models;
public record CourseViewModel
{
    public long Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public TeacherDTO Teacher { get; set; }
}
