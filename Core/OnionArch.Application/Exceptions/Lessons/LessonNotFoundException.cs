namespace OnionArch.Application.Exceptions.Lessons;
public class LessonNotFoundException : Exception
{
    public LessonNotFoundException(string message) : base(message) { }
}
