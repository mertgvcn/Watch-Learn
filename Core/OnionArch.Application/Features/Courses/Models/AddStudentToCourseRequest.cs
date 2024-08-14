using OnionArch.Domain.Entities;

namespace OnionArch.Application.Features.Courses.Models;
public record AddStudentToCourseRequest
{
    public required long CourseId { get; set; }
    public required Student Student { get; set; }
}
