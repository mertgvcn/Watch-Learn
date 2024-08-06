namespace OnionArch.Application.Exceptions.Auth;
public class UserAlreadyExistsException : Exception
{
    public UserAlreadyExistsException(string message) : base(message) { }
}
