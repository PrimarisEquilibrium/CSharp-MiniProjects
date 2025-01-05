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
            if (int.TryParse(stringIndex, out int updateIndex))
            {
                tasks.UpdateTask(updateIndex - 1, newContent);
                Console.WriteLine("Successfully updated task.");
            }
            else
            {
                Console.WriteLine("Couldn't parse `" + stringIndex + "` into an integer.");
            }
            break;
        case "delete":
            if (int.TryParse(argument, out int deleteIndex))
            {
                // Task number uses one-based indexing
                // Convert to zero-based indexing
                tasks.RemoveTask(deleteIndex - 1);
                Console.WriteLine("Successfully deleted task");
            }
            else
            {
                Console.WriteLine("Couldn't parse `" + argument + "` into an integer.");
            }
            break;
        case "mark-todo":
            if (int.TryParse(argument, out int todoIndex))
            {
                tasks.MarkTodo(todoIndex - 1);
                Console.WriteLine("Successfully marked task as `todo`");
            }
            else
            {
                Console.WriteLine("Couldn't parse `" + argument + "` into an integer.");
            }
            break;
        case "mark-in-progress":
            if (int.TryParse(argument, out int inprogressIndex))
            {
                tasks.MarkTodo(inprogressIndex - 1);
                Console.WriteLine("Successfully marked task as `in-progress`");
            }
            else
            {
                Console.WriteLine("Couldn't parse `" + argument + "` into an integer.");
            }
            break;
        case "mark-done":
            if (int.TryParse(argument, out int doneIndex))
            {
                tasks.MarkTodo(doneIndex - 1);
                Console.WriteLine("Successfully marked task as `done`");
            }
            else
            {
                Console.WriteLine("Couldn't parse `" + argument + "` into an integer.");
            }
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
            mark-todo <index>
            mark-in-progress <index>
            mark-done <index>
            exit
            ");
            break;
        default:
            Console.WriteLine("Invalid input, type `help` for valid commands.");
            continue;
        }
    }
}