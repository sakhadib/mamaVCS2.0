using System.Security.Cryptography;
using System.Text;

namespace mama.core.Utils;

public class Hasher
{
    
    private static readonly Hasher _instance = new Hasher();
    
    private Hasher(){}
    
    public static Hasher Instance => _instance;
    
    
    public string ComputeFileHash(string path)
    {
        using (var sha1 = SHA1.Create())
        {
            using (var stream = File.OpenRead(path))
            {
                var hash = sha1.ComputeHash(stream);
                return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
            }
        }
    }
    
    
    
    public string ComputeFileHashFromString(string content)
    {
        using (var sha1 = SHA1.Create())
        {
            byte[] contentBytes = Encoding.UTF8.GetBytes(content);
            byte[] hash = sha1.ComputeHash(contentBytes);
            return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
        }
    }
}