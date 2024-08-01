namespace OnionArch.Domain.Common;
public class EntityBase : IEntityBase
{
    public long Id { get; set; }
    public DateTime CreatedDate = DateTime.Now;
    public bool isDeleted { get; set; } = false;
}
