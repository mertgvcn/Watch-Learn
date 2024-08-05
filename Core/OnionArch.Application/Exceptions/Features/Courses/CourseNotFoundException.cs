namespace OnionArch.Application.Exceptions.Features.Courses;
public class CourseNotFoundException : Exception
{
    public CourseNotFoundException(string message) : base(message) { }
}
