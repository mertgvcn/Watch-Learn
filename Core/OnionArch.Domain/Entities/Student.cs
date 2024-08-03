namespace OnionArch.Domain.Entities;
public class Student : User
{
    public ICollection<Course> Courses { get; set; } = default!;
    public ICollection<StudentLessonProgress> StudentLessonProgresses { get; set; } = default!;

}
