namespace OnionArch.Application.DTOs;
public record LessonDTO
{
	public required long Id { get; init; }
	public required short LessonNumber { get; set; }
	public required string Title { get; set; }
	public required string Description { get; set; }
	public required int DurationInSeconds { get; set; }
}
