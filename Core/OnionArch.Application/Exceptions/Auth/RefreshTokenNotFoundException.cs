namespace OnionArch.Application.Exceptions.Auth;
public class RefreshTokenNotFoundException : Exception
{
    public RefreshTokenNotFoundException(string message) : base(message) { }
}
