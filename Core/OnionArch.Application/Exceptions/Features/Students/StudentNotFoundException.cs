namespace OnionArch.Application.Exceptions.Features.Students;
public class StudentNotFoundException : Exception
{
    public StudentNotFoundException(string message) : base(message) { }
}
