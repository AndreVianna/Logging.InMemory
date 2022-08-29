namespace Logging.InMemory;

public record InMemoryLogRecord
{
    public InMemoryLogRecord(string name, LogLevel level, EventId @event, string message, Exception? exception)
    {
        Name = name;
        Level = level;
        Event = @event;
        Message = message;
        Exception = exception;
    }
    
    public string Name { get; init; }
    public LogLevel Level { get; init; }
    public EventId Event { get; init; }
    public string Message { get; init; }
    public Exception? Exception { get; init; }

    public void Deconstruct(out string name, out LogLevel level, out EventId @event, out string message, out Exception? exception)
    {
        name = Name;
        level = Level;
        @event = Event;
        message = Message;
        exception = Exception;
    }
}