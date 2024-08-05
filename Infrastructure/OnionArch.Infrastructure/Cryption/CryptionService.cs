using Microsoft.Extensions.Configuration;
using OnionArch.Application.Interfaces.Services;
using System.Security.Cryptography;
using System.Text;

namespace OnionArch.Infrastructure.Cryption;
public sealed class CryptionService : ICryptionService
{
    private readonly IConfiguration _configuration;

    public CryptionService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task<string> Decrypt(string key)
    {
        string _key = _configuration["Crypto:key"];
        string privatekey = _configuration["Crypto:privateKey"];
        byte[] privatekeyByte = { };
        privatekeyByte = Encoding.UTF8.GetBytes(privatekey);
        byte[] _keybyte = { };
        _keybyte = Encoding.UTF8.GetBytes(_key);
        byte[] inputtextbyteArray = new byte[key.Replace(" ", "+").Length];
        //This technique reverses base64 encoding when it is received over the Internet.
        inputtextbyteArray = Convert.FromBase64String(key.Replace(" ", "+"));
        using (DESCryptoServiceProvider dEsp = new DESCryptoServiceProvider())
        {
            var memstr = new MemoryStream();
            var crystr = new CryptoStream(memstr, dEsp.CreateDecryptor(_keybyte, privatekeyByte), CryptoStreamMode.Write);
            crystr.Write(inputtextbyteArray, 0, inputtextbyteArray.Length);
            crystr.FlushFinalBlock();
            return Encoding.UTF8.GetString(memstr.ToArray());
        }
    }
}
