namespace OnionArch.Application.Features.Courses.Models;
public record UpdateCourseRequest
{
    public required long Id { get; init; }
    public string Title { get; set; }
    public string Description { get; set; }
    public long TeacherId { get; set; }
}
