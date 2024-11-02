using mama.Commands;
using mama.core;
using mama.core.Interfaces;

namespace mama.DesignPatterns.Factory;

public class CommandFactory
{
    public static ICommand CreateCommand(string commandName)
    {
        switch (commandName.ToLower())
        {
            case "shuru":
                return new ShuruCommand(new RepositoryInitializer());
            
            
            default:
                throw new ArgumentException("Invalid command name.");
        }
    }
}