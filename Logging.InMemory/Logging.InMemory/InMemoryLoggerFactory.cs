namespace Logging.InMemory;

public class InMemoryLoggerFactory : ILoggerFactory
{
    public ILogger CreateLogger(string categoryName) => new InMemoryLogger(categoryName);

    public void AddProvider(ILoggerProvider provider) => throw new NotImplementedException();

    public void Dispose() { }
}