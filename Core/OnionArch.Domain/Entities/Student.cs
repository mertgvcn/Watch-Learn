using OnionArch.Domain.Common;

namespace OnionArch.Domain.Entities;
public class Student : BaseEntity, IEditableEntity, ISoftDeletableEntity
{
    public string? EditedBy { get; set; }
    public DateTime? DateModified { get; set; }
    public bool IsDeleted { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Email { get; set; }
    public required string PhoneNumber { get; set; }
    public required string Password { get; set; }
    public ICollection<Course> Courses { get; set; } = default!;
    public ICollection<StudentLessonProgress> StudentLessonProgresses { get; set; } = default!;

}
