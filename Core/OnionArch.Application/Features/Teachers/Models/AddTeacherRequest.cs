using OnionArch.Application.DTOs;

namespace OnionArch.Application.Features.Teachers.Models;
public record AddTeacherRequest
{
    public required UserDTO User { get; set; }
}
