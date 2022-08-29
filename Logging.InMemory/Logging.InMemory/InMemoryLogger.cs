namespace Logging.InMemory;

public class InMemoryLogger : ILogger
{
    private readonly string _name;
    private readonly List<InMemoryLogRecord> _logs;

    public InMemoryLogger(string name)
    {
        _name = name;
        _logs = new();
    }

    public IReadOnlyList<InMemoryLogRecord> Logs => _logs;


    public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
    {
        var message = formatter(state, exception);
        _logs.Add(new(_name, logLevel, eventId, message, exception));
    }

    public bool IsEnabled(LogLevel logLevel) => true;

    public IDisposable BeginScope<TState>(TState state) => new NullScope();

    private class NullScope : IDisposable
    {
        public void Dispose()
        {
        }
    }
}