namespace OnionArch.Domain.Common;
public interface ISoftDeletableEntity
{
    public bool IsDeleted { get; set; }
}
