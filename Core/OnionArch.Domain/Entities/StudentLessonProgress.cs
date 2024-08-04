using OnionArch.Domain.Common;

namespace OnionArch.Domain.Entities;
public class StudentLessonProgress : BaseEntity, IEditableEntity, ISoftDeletableEntity
{
    public string? EditedBy { get; set; }
    public DateTime? DateModified { get; set; }
    public bool IsDeleted { get; set; } = false;
    public long StudentId { get; set; }
    public long LessonId { get; set; }
    public bool IsCompleted { get; set; } = false;
    public DateTime? DateCompleted { get; set; }
}
