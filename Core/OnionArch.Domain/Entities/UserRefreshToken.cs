using OnionArch.Domain.Common;

namespace OnionArch.Domain.Entities;
public class UserRefreshToken : BaseEntity, IEditableEntity, IDeletableEntity
{
    public string? EditedBy { get; set; }
    public DateTime? DateModified { get; set; }
    public required string Token { get; set; }
    public required DateTime ExpireDate { get; set; }
    public required long UserId { get; init; }
}
