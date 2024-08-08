namespace OnionArch.Application.DTOs;
public record TeacherDTO
{
    public required long Id { get; init; }
    public required UserDTO User { get; set; }
}
