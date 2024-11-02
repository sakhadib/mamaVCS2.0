using mama.core.Interfaces;

namespace mama.core;

public class RepositoryInitializer : IRepositoryInitializer
{
    private static readonly string MamaDirectory = ".mama";
    
    public void InitializeRepository()
    {
        if (!Directory.Exists(MamaDirectory))
        {
            Directory.CreateDirectory(MamaDirectory);
            Console.WriteLine("Repository initialized.");
        }
        else
        {
            Console.WriteLine("Repository already initialized.");
        }
    }

}