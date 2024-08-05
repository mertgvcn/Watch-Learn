using OnionArch.Domain.Common;

namespace OnionArch.Domain.Entities;
public class Student : BaseEntity, IEditableEntity, ISoftDeletableEntity
{
    public string? EditedBy { get; set; }
    public DateTime? DateModified { get; set; }
    public bool IsDeleted { get; set; } = false;
    public long UserId { get; set; }
    public User User { get; set; }
    public ICollection<Course> Courses { get; set; } = default!;
    public ICollection<StudentLessonProgress> StudentLessonProgresses { get; set; } = default!;

}
