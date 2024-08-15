namespace OnionArch.Application.Features.Courses.Models;
public sealed record MyCourseViewModel
{
	public required long Id { get; init; }
	public required string Title { get; set; }
	public required string ShortDescription { get; set; }
	public required string TeacherName { get; set; }
	public required short StudentProgressPercentage { get; set; }
}
