namespace OnionArch.Application.Exceptions.Features.Users;
public class UserNotFoundException : Exception
{
    public UserNotFoundException(string message) : base(message) { }
}
