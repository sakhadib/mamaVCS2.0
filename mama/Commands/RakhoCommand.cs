using mama.core.Interfaces;

namespace mama.Commands;

public class RakhoCommand : ICommand
{
    private readonly ICommitManager _commitManager;
    private readonly string _message;
    
    public RakhoCommand(ICommitManager commitManager, string message)
    {
        _commitManager = commitManager;
        _message = message;
    }
    
    public void Execute()
    {
        try
        {
            _commitManager.Commit(_message);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}