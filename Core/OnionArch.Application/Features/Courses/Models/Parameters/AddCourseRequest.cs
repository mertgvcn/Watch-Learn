namespace OnionArch.Application.Features.Courses.Models.Parameters;
public record AddCourseRequest
{
    public required string Title { get; set; }
    public required string ShortDescription { get; set; }
    public required string Description { get; set; }
    public required double Price { get; set; }
    public required long TeacherId { get; set; }
}
