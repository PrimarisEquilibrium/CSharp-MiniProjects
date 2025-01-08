using TaskTracker.Utilities;
using TaskTracker.Tasks;


static void ExecuteTaskAction(Action action, string successMessage)
{
    try
    {
        action();
        Console.WriteLine("Successfully updated task.");
    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
    }
}

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
            ExecuteTaskAction(
                () => tasks.UpdateTask(indexArg, stringArg),
                "Successfully updated task."
            );
            break;
        case "delete":
            ExecuteTaskAction(
                () => tasks.DeleteTask(indexArg),
                "Successfully removed task."
            );
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