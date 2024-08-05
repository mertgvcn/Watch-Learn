namespace OnionArch.Application.DTOs;
public record CourseDTO
{
    public required long Id { get; init; }
    public required string Title { get; set; }
    public required string Description { get; set; }
}
