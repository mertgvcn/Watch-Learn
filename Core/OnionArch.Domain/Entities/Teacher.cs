namespace OnionArch.Domain.Entities;
public class Teacher : User
{
    public ICollection<Course> Courses { get; set; }
}
