using OnionArch.Domain.Common;

namespace OnionArch.Domain.Entities;
public class Lesson : BaseEntity, IEditableEntity, ISoftDeletableEntity
{
    public string? EditedBy { get; set; }
    public DateTime? DateModified { get; set; }
    public bool IsDeleted { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public long CourseId { get; set; }
}
