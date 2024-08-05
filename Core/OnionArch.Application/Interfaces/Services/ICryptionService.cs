namespace OnionArch.Application.Interfaces.Services;
public interface ICryptionService
{
    Task<string> Encrypt(string plainText);
    Task<string> Decrypt(string encryptedText);
}
