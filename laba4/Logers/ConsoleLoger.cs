namespace laba4.Logers;

public class ConsoleLoger : ILoger
{
    public void Log(string message)
    {
        Console.WriteLine(message);
    }

    public void Log()
    {
        Console.WriteLine();
    }
}
