using TaskTracker.Utilities;
using TaskTracker.Tasks;

Console.WriteLine("Task Tracker CLI Application");

var tasks = new TasksManager();
var helpString = @"
add ""<task>""
update <index> ""<newContent>""
delete <index>
view
mark-todo <index>
mark-in-progress <index>
mark-done <index>
exit
";

while (true)
{
    var rawInput = Console.ReadLine();

    string command;
    int indexArg;
    string stringArg;

    if (rawInput is not null)
    {
        try
        {
            (command, indexArg, stringArg) = Utils.ParseCommand(rawInput);
        }
        catch (ArgumentException e)
        {
            Console.WriteLine(e.Message);
            continue;
        }

        // Program requests user to provide indices using one-based indexing
        // Tasks class uses zero-based indexing
        indexArg--;
    }
    else
    {
        Console.WriteLine("Please supply a non-null command, type `help` for valid commands.");
        continue;
    }


    switch(command)
    {
        case "add":
            tasks.AddTask(stringArg);
            Console.WriteLine("Successfully added task");
            break;
        case "update":
            try
            {
                tasks.UpdateTask(indexArg, stringArg);
            }
            catch (Exception e)
            {
                if (e is ArgumentOutOfRangeException || e is ArgumentException)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }
            }
            Console.WriteLine("Successfully updated task.");
            break;
        case "delete":
            tasks.RemoveTask(indexArg);
            Console.WriteLine("Successfully deleted task");
            break;
        case "mark-todo":
            tasks.MarkTodo(indexArg);
            Console.WriteLine("Successfully marked task as `todo`");
            break;
        case "mark-in-progress":
            tasks.MarkInProgress(indexArg);
            Console.WriteLine("Successfully marked task as `in-progress`");
            break;
        case "mark-done":
            tasks.MarkDone(indexArg);
            Console.WriteLine("Successfully marked task as `done`");
            break;
        case "view":
            tasks.DisplayTasks();
            break;
        case "exit":
            System.Environment.Exit(1);
            break;
        case "help":
            Console.WriteLine(helpString);
            break;
        default:
            Console.WriteLine("Invalid command, type `help` for valid commands.");
            continue;
    }
}