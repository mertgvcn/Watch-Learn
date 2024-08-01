namespace OnionArch.Domain.Common;
public interface IEditableEntity
{
    public string? EditedBy { get; set; }
    public DateTime? DateModified { get; set; }
}
