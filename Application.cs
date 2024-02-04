using DotnetDi.Repository.Interfaces;

namespace DotnetDi.Application;
public static class Application
{
    private static void PrintColor(ConsoleColor color, string message)
    {
        Console.ForegroundColor = color;
        Console.WriteLine(message);
        Console.ResetColor();
    }

    public static void ClientController(IUnitOfWork uow)
    {
        PrintColor(ConsoleColor.Green, "Running ClientController");
        PrintColor(ConsoleColor.Yellow, $"\t{uow}");
        PrintColor(ConsoleColor.Green, "finished ClientController");
    }
}
