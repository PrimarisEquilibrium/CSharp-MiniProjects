namespace TaskTracker;

/// <summary>
/// Program class.
/// </summary>
public class Program
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
    static (string Command, string Argument) ParseCommand(string rawCommand)
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

    static void Main(string[] args)
    {
        Console.WriteLine("Task Tracker CLI Application");

        var tasks = new TaskManager.Tasks();

        while (true)
        {
            var rawInput = Console.ReadLine();

            string command;
            string argument;

            if (rawInput is not null)
            {
                (command, argument) = ParseCommand(rawInput);
            }
            else
            {
                Console.WriteLine("Please supply a non-null command, type `help` for valid commands.");
                continue;
            }

            Console.WriteLine("[DEBUG]: `{cmd: " + command + "} {arg: " + argument + "}`");

            switch(command)
            {
                case "add":
                    break;
                case "update":
                    break;
                case "delete":
                    break;
                case "view":
                    break;
                case "inprogress":
                    break;
                case "complete":
                    break;
                case "exit":
                    System.Environment.Exit(1);
                    break;
                case "help":
                    Console.WriteLine(@"
                    add <task>
                    update <task/index>
                    delete <task/index>
                    view
                    inprogress <task/index>
                    complete <task/index>
                    ");
                    break;
                default:
                    Console.WriteLine("Invalid input, type `help` for valid commands.");
                    continue;
            }
        }

        // add <task>
        // update <task/index>
        // delete <task/index>
        // view
        // inprogress <task/index>
        // complete <task/index>
    }
}