using OnionArch.Domain.Common;

namespace OnionArch.Domain.Entities;
public class CourseComment : BaseEntity, IEditableEntity, ISoftDeletableEntity
{
    public string? EditedBy { get; set; }
    public DateTime? DateModified { get; set; }
    public bool IsDeleted { get; set; } = false;
    public long CourseId { get; set; }
    public long StudentId { get; set; }
    public Student Student { get; set; } = default!;
    public required string Comment { get; set; }
    public required short Rating { get; set; }
}
