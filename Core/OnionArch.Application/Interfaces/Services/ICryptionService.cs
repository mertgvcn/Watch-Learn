namespace OnionArch.Application.Interfaces.Services;
public interface ICryptionService
{
    string Encrypt(string plainText);
    string Decrypt(string encryptedText);
}
