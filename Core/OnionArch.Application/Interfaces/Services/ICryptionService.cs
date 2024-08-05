namespace OnionArch.Application.Interfaces.Services;
public interface ICryptionService
{
    Task<string> Decrypt(string key);
}
