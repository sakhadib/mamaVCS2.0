using System.Security.Cryptography;

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
}