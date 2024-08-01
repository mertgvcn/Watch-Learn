namespace OnionArch.Domain.Common;
public abstract class BaseEntity
{
    public long Id { get; init; }
    public DateTime DateCreated { get; init; } = DateTime.Now;
}
