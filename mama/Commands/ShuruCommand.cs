using mama.core.Interfaces;

namespace mama.Commands;

public class ShuruCommand : ICommand
{
    private readonly IRepositoryInitializer _repositoryInitializer;
    
    public ShuruCommand(IRepositoryInitializer repositoryInitializer)
    {
        _repositoryInitializer = repositoryInitializer;
    }
    
    public void Execute()
    {
        _repositoryInitializer.InitializeRepository();
    }
}