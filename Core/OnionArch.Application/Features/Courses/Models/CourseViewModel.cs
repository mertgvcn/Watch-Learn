namespace OnionArch.Application.Features.Courses.Models;
public record CourseViewModel
{
    public required long Id { get; init; }
    public string Title { get; set; }
    public string Description { get; set; }
    public TeacherCourseViewModel Teacher { get; set; }
}
