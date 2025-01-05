﻿using TaskTracker.Utilities;
using TaskTracker.Tasks;

Console.WriteLine("Task Tracker CLI Application");

var tasks = new TasksManager();

while (true)
{
    var rawInput = Console.ReadLine();

    string command;
    int indexArg;
    string stringArg;

    if (rawInput is not null)
    {
        (command, indexArg, stringArg) = Utils.ParseCommand(rawInput);

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
            tasks.UpdateTask(indexArg, stringArg);
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
            tasks.MarkTodo(indexArg);
            Console.WriteLine("Successfully marked task as `in-progress`");
            break;
        case "mark-done":
            tasks.MarkTodo(indexArg);
            Console.WriteLine("Successfully marked task as `done`");
            break;
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