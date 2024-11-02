using mama.core.Interfaces;

namespace mama.Commands;

public class DekhoCommand : ICommand
{
    private readonly IStagingArea _stagingArea;
    
    public DekhoCommand(IStagingArea stagingArea)
    {
        _stagingArea = stagingArea;
    }

    public void Execute()
    {
        try
        {
            _stagingArea.StageFiles(Environment.CurrentDirectory);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}