namespace OnionArch.Application.Features.Students.Models;
public sealed record MyCoursesViewModel
{
	public required long Id { get; init; }
	public required string Title { get; set; }
	public required string ShortDescription { get; set; }
	public required string Description { get; set; }
	public required string TeacherName { get; set; }
}
