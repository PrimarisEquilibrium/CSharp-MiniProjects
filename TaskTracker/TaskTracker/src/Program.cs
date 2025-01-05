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

    Console.WriteLine("[DEBUG]: `{cmd: " + command + "} {arg: " + argument + "}`");
    tasks.DisplayTasks();

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
            break;
        case "delete":
            if (int.TryParse(argument, out int result))
            {
                // Task number uses one-based indexing
                // Convert to zero-based indexing
                tasks.RemoveTaskByIndex(result - 1);
            }
            else
            {
                tasks.RemoveTaskByName(argument);
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
}