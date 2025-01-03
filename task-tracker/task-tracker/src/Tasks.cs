class Tasks
{
    public List<string> TaskList {get;set;} = [];

    public Tasks() {}

    /// <summary>
    /// Adds an arbitrary amount of tasks to the list.
    /// </summary>
    /// <param name="tasks">The tasks to add.</param>
    public void AddTask(params string[] tasks)
    {
        foreach (var task in tasks)
        {
            TaskList.Add(task);
        }
    }

    public void RemoveTaskByIndex(params int[] indices)
    {
        foreach (var index in indices)
        {
            TaskList.RemoveAt(index);
        }
    }

    /// <summary>
    /// Removes an arbitrary amount of tasks from the list.
    /// </summary>
    /// <param name="task">The tasks to remove.</param>
    public void RemoveTaskByName(params string[] tasks)
    {
        foreach(var task in tasks)
        {
            TaskList = TaskList.Where(t => t != task).ToList();
        }
    }

    /// <summary>
    /// Displays all the tasks to do.
    /// </summary>
    public void DisplayTasks()
    {
        for (var i = 0; i < TaskList.Count; i++)
        {
            Console.WriteLine($"{i + 1}) {TaskList[i]}");
        }
    }
};