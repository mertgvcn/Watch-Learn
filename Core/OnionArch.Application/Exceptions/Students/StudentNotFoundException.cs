namespace OnionArch.Application.Exceptions.Students;
public class StudentNotFoundException : Exception
{
    public StudentNotFoundException(string message) : base(message) { }
}
