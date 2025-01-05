using TaskTracker.Utilities;

Console.WriteLine("Task Tracker CLI Application");

var tasks = new TaskManager.Tasks();

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