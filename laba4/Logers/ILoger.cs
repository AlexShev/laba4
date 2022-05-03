namespace laba4.Logers;

public interface ILoger
{
    void Log(string message);
    void Log();

    void Close();
}
