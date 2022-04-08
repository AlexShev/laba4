namespace laba4.Logers;

public class FileLoger : ILoger, IDisposable
{
    private StreamWriter _fileStream = new("log.txt", append: true);

    public void Log(string message)
    {
        _fileStream.WriteLine(message);
    }

    public void Log()
    {
        _fileStream.WriteLine();
    }

    public void Close()
    {
        _fileStream?.Close();
    }

    public void Dispose()
    {
        _fileStream?.Dispose();
    }
}
