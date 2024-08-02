using OnionArch.Domain.Common;

namespace OnionArch.Domain.Entities;
public class StudentLessonProgress : BaseEntity, IEditableEntity, ISoftDeletableEntity
{
    public bool IsDeleted { get; set; } = false;
    public string? EditedBy { get; set; }
    public DateTime? DateModified { get; set; }
    public long StudentId { get; set; }
    public Student Student { get; set; } = default!;
    public long LessonId { get; set; }
    public Lesson Lesson { get; set; } = default!;
    public bool IsCompleted { get; set; } = false;
    public DateTime? DateCompleted { get; set; }
}
