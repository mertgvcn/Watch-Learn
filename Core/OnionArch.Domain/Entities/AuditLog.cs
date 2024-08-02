using OnionArch.Domain.Common;

namespace OnionArch.Domain.Entities;
public sealed class AuditLog : BaseEntity
{
    public required string Name { get; set; } = default!;
    public required string Object { get; set; } = default!;
    public required string Mutation { get; set; } = default!;
    public DateTime TimeStamp { get; } = DateTime.Now;
    public required string OldObjectValue { get; set; } = default!;
}
