using mama.core.Interfaces;

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
            
        }
    }


    
}