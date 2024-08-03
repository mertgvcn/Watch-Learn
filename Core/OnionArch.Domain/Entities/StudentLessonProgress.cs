using OnionArch.Domain.Common;

namespace OnionArch.Domain.Entities;
public class StudentLessonProgress : BaseEntity, IEditableEntity, ISoftDeletableEntity
{
    public string? EditedBy { get; set; }
    public DateTime? DateModified { get; set; }
    public bool IsDeleted { get; set; } = false;
    public required long StudentId { get; set; }
    public Student Student { get; set; } = default!;
    public required long LessonId { get; set; }
    public Lesson Lesson { get; set; } = default!;
    public required bool IsCompleted { get; set; } = false;
    public DateTime? DateCompleted { get; set; }
}
