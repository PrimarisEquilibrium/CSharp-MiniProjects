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
    /// <item><c>IndexArgument</c>: The index argument portion of the input string, or -1 if no argument is provided.</item>
    /// <item><c>StringArgument</c>: The string argument portion of the input string, or an empty string if no argument is provided.</item>
    /// </list>
    /// </returns>
    public static (string Command, int IndexArg, string StringArg) ParseCommand(string rawCommand)
    {
        string command = rawCommand;
        int indexArg = -1;
        string stringArg = "";

        // Extract string argument, if it exists
        var indexOfStringStart = rawCommand.IndexOf('"');
        if (indexOfStringStart != -1)
        {
            stringArg = rawCommand[(indexOfStringStart + 1)..^1];   

            // Slice off the string argument portion of rawCommand, if it exists
            rawCommand = rawCommand[..indexOfStringStart];
        }

        // Extract index argument, if it exists
        var indexOfSpace = rawCommand.IndexOf(' ');
        if (indexOfSpace != -1)
        {
            if (int.TryParse(rawCommand[(indexOfSpace + 1)..], out int arg))
            {
                indexArg = arg;
            }

            // Extract command
            command = rawCommand[..indexOfSpace];
        }

        return (Command: command, IndexArg: indexArg, StringArg: stringArg);
    }
}