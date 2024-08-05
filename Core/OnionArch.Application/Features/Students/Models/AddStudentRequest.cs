using OnionArch.Domain.Entities;

namespace OnionArch.Application.Features.Students.Models;
public record AddStudentRequest
{
    public required User User { get; set; }
}
