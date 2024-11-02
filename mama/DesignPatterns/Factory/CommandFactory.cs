using mama.Commands;
using mama.core;
using mama.core.Interfaces;

namespace mama.DesignPatterns.Factory;

public class CommandFactory
{
    public static ICommand CreateCommand(string[] args)
    {
        switch (args[0].ToLower())
        {
            case "shuru":
                return new ShuruCommand(new RepositoryInitializer());
            
            
            case "dekho":
                return new DekhoCommand(new StagingArea());
            
            
            case "rakho":
                if (args.Length < 2)
                {
                    throw new ArgumentException("Commit message is required.");
                }
                
                string commitMessage = string.Join(" ", args, 1, args.Length - 1);
                return new RakhoCommand(new CommitManager(), commitMessage);
            
            
            default:
                throw new ArgumentException("Invalid command name.");
        }
    }
}