using TaskTracker.Utilities;

namespace TaskTracker.UnitTests;

public class UtilsTests
{
    [Fact]
    public void CanParseCommandWithNoArgs()
    {
        var (command, argument) = Utils.ParseCommand("help");
        Assert.Equal("help", command);
        Assert.Equal("", argument);
    }

    [Fact]
    public void CanParseCommandWithArgs()
    {
        var (command, argument) = Utils.ParseCommand("add \"Brush teeth\"");
        Assert.Equal("add", command);
        Assert.Equal("\"Brush teeth\"", argument);
    }
}