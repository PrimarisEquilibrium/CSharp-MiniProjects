using TaskTracker.Utilities;
using TaskTracker.Tasks;

Console.WriteLine("Task Tracker CLI Application");

var tasks = new TasksManager();

while (true)
{
    var rawInput = Console.ReadLine();

    string command;
    string argument;

    if (rawInput is not null)
    {
        (command, argument) = Utils.ParseCommand(rawInput);
    }
    else
    {
        Console.WriteLine("Please supply a non-null command, type `help` for valid commands.");
        continue;
    }

    // Commands with arguments
    if (argument != "")
    {
        switch(command)
    {
        case "add":
            tasks.AddTask(argument);
            Console.WriteLine("Successfully added task");
            break;
        case "update":
            // Update command contains an index and new content as arguments
            var (stringIndex, newContent) = Utils.ParseCommand(argument);
            if (int.TryParse(stringIndex, out int index))
            {
                tasks.UpdateTask(index - 1, newContent);
            }
            else
            {
                Console.WriteLine("Couldn't parse `" + stringIndex + "` into an integer.");
            }
            break;
        case "delete":
            if (int.TryParse(argument, out int result))
            {
                // Task number uses one-based indexing
                // Convert to zero-based indexing
                tasks.RemoveTask(result - 1);
            }
            else
            {
                Console.WriteLine("Couldn't parse `" + argument + "` into an integer.");
            }
            Console.WriteLine("Successfully deleted task");
            break;
        case "inprogress":
            break;
        case "complete":
            break;
        default:
            Console.WriteLine("Invalid input, type `help` for valid commands.");
            continue;
        }
    }
    // Commands without arguments
    else
    {
        switch(command)
    {
        case "view":
            tasks.DisplayTasks();
            break;
        case "exit":
            System.Environment.Exit(1);
            break;
        case "help":
            Console.WriteLine(@"
            add <task>
            update <index> <newContent>
            delete <index>
            view
            inprogress <index>
            complete <index>
            exit
            ");
            break;
        default:
            Console.WriteLine("Invalid input, type `help` for valid commands.");
            continue;
        }
    }
}