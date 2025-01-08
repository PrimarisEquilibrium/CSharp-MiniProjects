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
        var splitCommand = rawCommand.Split(' ', 3);

        // Default initialization where rawCommand only supplies a Command
        // No work needs to be done checking for an argumentless command
        string command = splitCommand[0];
        int indexArg = -1;
        string stringArg = "";

        // Command and one argument are given
        if (splitCommand.Length == 2)
        {
            var argument = splitCommand[1];

            var firstQuoteIndex = argument.IndexOf('"');
            var lastQuoteIndex = argument.LastIndexOf('"');
            // String argument must be wrapped in double quotes
            if (firstQuoteIndex != lastQuoteIndex && firstQuoteIndex < lastQuoteIndex && lastQuoteIndex == argument.Length - 1)
            {
                stringArg = argument;
            }
            else
            {
                indexArg = int.TryParse(splitCommand[1], out int intArg)
                    ? intArg
                    // If argument fails to be parsed as an integer
                    // it most likely is a syntactically incorrect string argument 
                    : throw new ArgumentException("Command string argument must be wrapped in double quotes.", nameof(rawCommand));
            }
        }
        // Command and all arguments are given
        else if (splitCommand.Length == 3)
        {
            indexArg = int.TryParse(splitCommand[1], out int intArg)
                ? intArg
                : throw new ArgumentException("Failed to parse 'indexArg' to an integer.", nameof(rawCommand));
            stringArg = splitCommand[2];
        }

        return (Command: command, IndexArg: indexArg, StringArg: stringArg);
    }
}