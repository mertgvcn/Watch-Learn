namespace OnionArch.Application.Features.Lessons.Models;
public record UpdateLessonRequest
{
    public required long Id { get; init; }
    public string Title { get; set; } = default!;
    public TimeSpan Duration { get; set; } = default!;
    public string Description { get; set; } = default!;
}
