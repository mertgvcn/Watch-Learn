namespace OnionArch.Application.Features.Lessons.Models;
public record AddLessonRequest
{
    public required string Title { get; set; }
    public required string Description { get; set; }
    public required TimeSpan Duration { get; set; }
    public required long CourseId { get; set; }

}
