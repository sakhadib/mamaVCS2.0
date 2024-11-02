using mama.core.Interfaces;
using mama.core.Utils;

namespace mama.core;

public class StagingArea : IStagingArea
{
    private readonly string _stagingDirectory = ".mama/staging";
    
    public StagingArea()
    {
        if (!Directory.Exists(_stagingDirectory))
        {
            Directory.CreateDirectory(_stagingDirectory);
        }
    }

    public void StageFiles(string path)
    {
        if(!Directory.Exists(path))
        {
            throw new ArgumentException("Invalid path.");
        }
        
        var files = Directory.GetFiles(path, "*", SearchOption.AllDirectories);
        foreach (var file in files)
        {
            if (FileComparisonHelper.Instance.HasFileChanged(file, _stagingDirectory))
            {
                StageFile(file);
            }
        }
    }
    
    private void StageFile(string filePath)
    {
        string hash = Hasher.Instance.ComputeFileHash(filePath);
        string relativePath = Path.GetFileName(filePath);
        string hashFilePath = Path.Combine(_stagingDirectory, relativePath + ".hash");
        
        string hashFileDirectory = Path.GetDirectoryName(hashFilePath);
        if(!string.IsNullOrEmpty(hashFileDirectory) && !Directory.Exists(hashFileDirectory))
        {
            Directory.CreateDirectory(hashFileDirectory);
        }
        
        
        File.WriteAllText(hashFilePath, hash);
        Console.WriteLine($"Staged {filePath}");
    }
}