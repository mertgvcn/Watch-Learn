using OnionArch.Domain.Common;

namespace OnionArch.Domain.Entities;
public class CourseComment : BaseEntity, IEditableEntity, ISoftDeletableEntity
{
    public string? EditedBy { get; set; }
    public DateTime? DateModified { get; set; }
    public bool IsDeleted { get; set; }
    public required long CourseId { get; set; }
    public required long StudentId { get; set; }
    public required string Comment { get; set; }
    public required short Rating { get; set; }
}
