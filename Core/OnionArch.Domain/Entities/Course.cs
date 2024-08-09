using OnionArch.Domain.Common;

namespace OnionArch.Domain.Entities;
public class Course : BaseEntity, IEditableEntity, ISoftDeletableEntity, IAuditable
{
    public string? EditedBy { get; set; }
    public DateTime? DateModified { get; set; }
    public bool IsDeleted { get; set; } = false;
    public required string Title { get; set; }
    public required string Description { get; set; }
    public required double Price { get; set; }
    public TimeSpan TotalLessonDuration { get; set; }
    public required long TeacherId { get; set; }
    public Teacher Teacher { get; set; } = default!;
    public ICollection<Lesson> Lessons { get; set; } = default!;
    public ICollection<Student> Students { get; set; } = default!;
}
