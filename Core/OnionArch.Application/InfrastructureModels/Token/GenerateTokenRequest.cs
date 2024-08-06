using OnionArch.Domain.Enumerators;

namespace OnionArch.Application.InfrastructureModels.Models;
public record GenerateTokenRequest
{
    public required long UserId { get; set; }
    public required Roles Role { get; set; }
}
