namespace Logging.InMemory;

public class InMemoryLoggerTests
{
    [Fact]
    public void InMemoryLogger_Constructor_CreatesLoggerWithEmptyLogs()
    {
        var subject = new InMemoryLogger("Name");

        subject.Logs.Should().BeEmpty();
    }

    [Fact]
    public void InMemoryLogger_IsEnabled_ReturnsTrue_ForAnyLevel()
    {
        var subject = new InMemoryLogger("Name");

        subject.IsEnabled(LogLevel.Trace).Should().BeTrue();
        subject.IsEnabled(LogLevel.Debug).Should().BeTrue();
        subject.IsEnabled(LogLevel.Information).Should().BeTrue();
        subject.IsEnabled(LogLevel.Warning).Should().BeTrue();
        subject.IsEnabled(LogLevel.Error).Should().BeTrue();
        subject.IsEnabled(LogLevel.Critical).Should().BeTrue();
        subject.IsEnabled(LogLevel.None).Should().BeTrue();
    }


    [Fact]
    public void InMemoryLogger_BeginScope_ReturnsNullScope()
    {
        var subject = new InMemoryLogger("Name");

        using var result = subject.BeginScope(new object());
    }

    [Fact]
    public void InMemoryLogger_Log_AddsLogToLogs()
    {
        var subject = new InMemoryLogger("Name");

        var exception = new InvalidOperationException("Some exception.");
        subject.LogError(42, exception, "Some log message with {data}.", "some value");

        subject.Logs.Should().HaveCount(1);
        subject.Logs[0].Name.Should().Be("Name");
        subject.Logs[0].Exception.Should().Be(exception);
        subject.Logs[0].Message.Should().Be("Some log message with some value.");
        subject.Logs[0].Level.Should().Be(LogLevel.Error);
        subject.Logs[0].Event.Should().Be(new EventId(42));
    }
}