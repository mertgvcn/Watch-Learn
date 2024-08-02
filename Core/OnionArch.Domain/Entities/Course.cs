using OnionArch.Domain.Common;

namespace OnionArch.Domain.Entities;
public class Course : BaseEntity, IEditableEntity, ISoftDeletableEntity, IAuditable
{
    public string? EditedBy { get; set; }
    public DateTime? DateModified { get; set; }
    public bool IsDeleted { get; set; } = false;
    public string Title { get; set; }
    public string Description { get; set; }
    public ICollection<Lesson> Lessons { get; set; } = default!;
    public ICollection<Student> Students { get; set; } = default!;
}
