namespace OnionArch.Application.Features.Courses.Models.Views;
public sealed record CurrentStudentCourseViewModel
{
	public required long Id { get; init; }
	public required string Title { get; set; }
	public required string ShortDescription { get; set; }
	public required string ImgUrl { get; set; }
	public required string TeacherName { get; set; }
	public required short StudentProgressPercentage { get; set; }
}
