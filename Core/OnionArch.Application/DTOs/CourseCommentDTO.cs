namespace OnionArch.Application.DTOs;
public record CourseCommentDTO
{
	public required long Id { get; set; }
	public required string StudentName { get; set; }
	public required string Comment { get; set; }
	public required short Rating { get; set; }
}
