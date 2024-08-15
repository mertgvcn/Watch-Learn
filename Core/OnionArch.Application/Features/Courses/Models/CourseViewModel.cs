namespace OnionArch.Application.Features.Courses.Models;
public record CourseViewModel
{
	public required long Id { get; init; }
	public required string Title { get; set; }
	public required string ShortDescription { get; set; }
	public required double Price { get; set; }
	public required string TeacherName { get; set; }
	public required int LessonCount { get; set; }
	public required int TotalLessonDuration { get; set; }
}
