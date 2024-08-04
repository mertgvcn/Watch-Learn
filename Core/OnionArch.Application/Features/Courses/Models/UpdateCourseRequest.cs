namespace OnionArch.Application.Features.Courses.Models;
public record UpdateCourseRequest
{
    public long Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public long TeacherId { get; set; }
}
