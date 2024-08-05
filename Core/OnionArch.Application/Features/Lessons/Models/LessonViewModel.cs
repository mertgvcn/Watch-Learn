namespace OnionArch.Application.Features.Lessons.Models;
public record LessonViewModel
{
    public required long Id { get; init; }
    public required string Title { get; set; }
    public required string Description { get; set; }
    public required long CourseId { get; init; }
}
