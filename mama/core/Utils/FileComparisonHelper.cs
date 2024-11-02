namespace mama.core.Utils;

public class FileComparisonHelper
{
    private static FileComparisonHelper _instance;
    
    private FileComparisonHelper(){}
    
    public static FileComparisonHelper Instance => _instance;
    
    public bool HasFileChanged(string filePath, string stagingDirectory)
    {
        string currentHash = Hasher.Instance.ComputeFileHash(filePath);
        string hashFilePath = Hasher.Instance.ComputeFileHash(Path.Combine(stagingDirectory, filePath));
        
        if (File.Exists(hashFilePath))
        {
            string previousHash = File.ReadAllText(hashFilePath);
            return !currentHash.Equals(previousHash);
        }
        
        return true;
    }
}