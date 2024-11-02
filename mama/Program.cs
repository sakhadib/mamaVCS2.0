
using mama.core.Interfaces;
using mama.DesignPatterns.Factory;


namespace mama;
class Program
{
    static void Main(string[] args)
    {
        if (args.Length > 0)
        {
            try
            {
                ICommand command = CommandFactory.CreateCommand(args);
                command.Execute();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        else
        {
            Console.WriteLine("No command provided.");
        }
    }
}

