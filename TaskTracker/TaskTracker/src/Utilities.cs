namespace TaskTracker.Utilities;

public static class Utils
{
    /// <summary>
    /// Parses a raw command string into its command and argument components.
    /// </summary>
    /// <param name="rawCommand">The raw input string containing the command and optional arguments.</param>
    /// <returns>
    /// A tuple containing:
    /// <list type="bullet">
    /// <item><c>Command</c>: The main command extracted from the input string.</item>
    /// <item><c>Argument</c>: The argument portion of the input string, or an empty string if no argument is provided.</item>
    /// </list>
    /// </returns>
    public static (string Command, string Argument) ParseCommand(string rawCommand)
    {
        string command;
        string argument;

        var indexOfSpace = rawCommand.IndexOf(' ');

        // indexOfSpace is -1 if the command is argumentless
        if (indexOfSpace != -1)
        {
            command = rawCommand[..indexOfSpace];
            argument = rawCommand[(indexOfSpace + 1)..];
        }
        else
        {
            command = rawCommand;
            argument = "";
        }

        return (Command: command, Argument: argument);
    }
}