using mama.core.Interfaces;
using mama.core.Utils;

namespace mama.core;

public class CommitManager : ICommitManager
{
    
    private readonly string _commitsDirectory = ".mama/commits";
    private readonly string _stagingAreaDirectory = ".mama/staging";

    public CommitManager()
    {
        if (!Directory.Exists(_commitsDirectory))
        {
            Directory.CreateDirectory(_commitsDirectory);
        }
    }

    public void Commit(string message)
    {
        if (!Directory.Exists(_stagingAreaDirectory) || Directory.GetFiles(_stagingAreaDirectory).Length == 0)
        {
            Console.WriteLine("No changes to commit.");
            return;
        }
        
        string commitId = GenerateCommitId(message);
        string commitPath = Path.Combine(_commitsDirectory, commitId);
        
        Directory.CreateDirectory(commitPath);
        
        var files = Directory.GetFiles(_stagingAreaDirectory);
        foreach (var file in files)
        {
            string fileName = Path.GetFileName(file);
            File.Copy(file, Path.Combine(commitPath, fileName));
            File.Delete(file);
        }
        
        File.WriteAllText(Path.Combine(commitPath, "message.txt"), message);
        Console.WriteLine($"Committed {commitId}");
    }
    
    private string GenerateCommitId(string message)
    {
        string commitContent = $"{DateTime.UtcNow.ToString("o")}\n{message}";
        return Hasher.Instance.ComputeFileHashFromString(commitContent);
    }
}