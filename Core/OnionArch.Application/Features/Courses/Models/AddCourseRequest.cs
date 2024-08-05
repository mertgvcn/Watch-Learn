namespace OnionArch.Application.Features.Courses.Models;
public record AddCourseRequest
{
    public required string Title { get; set; }
    public required string Description { get; set; }
    public required long TeacherId { get; set; }
}
