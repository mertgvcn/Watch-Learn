using OnionArch.Domain.Common;

namespace OnionArch.Domain.Entities;
public class StudentLessonProgress : IEditableEntity, ISoftDeletableEntity
{
    public bool IsDeleted { get; set; } = false;
    public string? EditedBy { get; set; }
    public DateTime? DateModified { get; set; }
    public required long StudentId { get; set; }
    public Student Student { get; set; } = default!;
    public required long LessonId { get; set; }
    public Lesson Lesson { get; set; } = default!;
    public required bool IsCompleted { get; set; } = false;
    public DateTime? DateCompleted { get; set; }
}
