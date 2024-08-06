namespace OnionArch.Application.Exceptions.Courses;
public class CourseNotFoundException : Exception
{
    public CourseNotFoundException(string message) : base(message) { }
}
