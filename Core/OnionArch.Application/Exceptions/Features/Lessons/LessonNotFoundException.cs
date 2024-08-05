namespace OnionArch.Application.Exceptions.Features.Lessons;
public class LessonNotFoundException : Exception
{
    public LessonNotFoundException(string message) : base(message) { }
}
