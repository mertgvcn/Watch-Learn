namespace OnionArch.Application.DTOs;
public record StudentDTO
{
    public required long Id { get; init; }
    public required UserDTO User { get; set; }
}
