namespace OnionArch.Domain.Common;
public abstract class BaseEntity : IBaseEntity
{
    public long Id { get; init; }
    public DateTime DateCreated { get; init; } = DateTime.Now;
}
