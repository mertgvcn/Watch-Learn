namespace OnionArch.Application.Features.Courses.Models;
public record AddCourseRequest
{
    public string Title { get; set; }
    public string Description { get; set; }
    public long TeacherId { get; set; }
}
