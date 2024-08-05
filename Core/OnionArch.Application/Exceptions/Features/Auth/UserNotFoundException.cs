namespace OnionArch.Application.Exceptions.Features.Auth;
public class UserNotFoundException : Exception
{
    public UserNotFoundException(string message) : base(message) { }
}
