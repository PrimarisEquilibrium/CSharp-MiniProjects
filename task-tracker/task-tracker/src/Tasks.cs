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

    /// <summary>
    /// Removes an arbitrary amount of tasks by indices.
    /// </summary>
    /// <param name="indices">The tasks to remove given their indices.</param>
    public void RemoveTaskByIndex(params int[] indices)
    {
        var count = 0;
        foreach (var index in indices)
        {
            // When an element from a list is deleted all
            // index positions are shifted by the current
            // iteration - 1
            TaskList.RemoveAt(index - count);
            count++;
        }
    }

    /// <summary>
    /// Removes an arbitrary amount of tasks from the list by name/value.
    /// </summary>
    /// <param name="task">The tasks to remove given their names.</param>
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