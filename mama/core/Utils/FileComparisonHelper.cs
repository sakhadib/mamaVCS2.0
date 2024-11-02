namespace mama.core.Utils;

public class FileComparisonHelper
{ 
    private static readonly FileComparisonHelper _instance = new FileComparisonHelper();
    
    private FileComparisonHelper(){}

    public static FileComparisonHelper Instance => _instance;
    
    public bool HasFileChanged(string filePath, string stagingDirectory)
    {
        if (string.IsNullOrEmpty(filePath))
        {
            throw new ArgumentException("Invalid file path.");
        }
        
        if (string.IsNullOrEmpty(stagingDirectory))
        {
            throw new ArgumentException("Invalid staging directory.");
        }
        
        string currentHash = Hasher.Instance.ComputeFileHash(filePath);
        string hashFilePath = Path.Combine(stagingDirectory, Path.GetFileName(filePath) + ".hash");

        if (File.Exists(hashFilePath))
        {
            string previousHash = File.ReadAllText(hashFilePath);
            return !currentHash.Equals(previousHash);
        }
        
        return true;
    }
}