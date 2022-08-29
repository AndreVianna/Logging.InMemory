using Xunit;

namespace Logging.InMemory;

public class InMemoryLoggerFactoryTests
{
    [Fact]
    public void InMemoryLoggerFactory_CreateLogger_ReturnsInMemoryLogger_AndDisposes()
    {
        using var subject = new InMemoryLoggerFactory();

        var result = subject.CreateLogger("Name");

        result.Should().BeOfType<InMemoryLogger>();
    }

    [Fact]
    public void InMemoryLoggerFactory_AddProvider_Throws()
    {
        var subject = new InMemoryLoggerFactory();

        [ExcludeFromCodeCoverage]
        void InvalidAction() => subject.AddProvider(null!);
        var action = InvalidAction;

        action.Should().Throw<NotImplementedException>();
    }
}