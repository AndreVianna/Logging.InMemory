namespace Logging.InMemory;

public class InMemoryLogRecordTests
{
    [Fact]
    public void InMemoryLogRecord_Constructor_CreatesObject()
    {
        var exception = new InvalidOperationException();
        var (name, level, eventId, message, exception1) = new InMemoryLogRecord("Name", LogLevel.Information, 1, "Some log message.", exception);

        name.Should().Be("Name");
        level.Should().Be(LogLevel.Information);
        eventId.Should().Be(new EventId(1));
        message.Should().Be("Some log message.");
        exception1.Should().Be(exception);
    }
}