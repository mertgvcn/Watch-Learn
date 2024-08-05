using OnionArch.Domain.Common;
using OnionArch.Domain.Enumerators;

namespace OnionArch.Domain.Entities;
public class User : BaseEntity, IEditableEntity, ISoftDeletableEntity
{
    public string? EditedBy { get; set; }
    public DateTime? DateModified { get; set; }
    public bool IsDeleted { get; set; }
    public required Roles Role { get; set; } = Roles.Student;
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Email { get; set; }
    public required string PhoneNumber { get; set; }
    public required string Password { get; set; }
    public Student? Student { get; set; }
    public Teacher? Teacher { get; set; }
}
