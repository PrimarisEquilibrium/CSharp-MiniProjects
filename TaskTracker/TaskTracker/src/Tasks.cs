namespace TaskTracker.Tasks;

/// <summary>
/// An enum representing the status of a task.
/// </summary>
public enum TaskStatus
{
    Todo,
    Inprogress,
    Done
}

public struct Task(string content, TaskStatus status)
{
    public string Content {get; set;} = content;
    public TaskStatus Status {get; set;} = status;
}

public class TasksManager
{
    public List<Task> TaskList = [];

    public TasksManager() {}

    /// <summary>
    /// Adds an arbitrary amount of tasks to the list.
    /// </summary>
    /// <param name="tasks">The tasks to add.</param>
    public void AddTask(params string[] tasks)
    {
        foreach (var task in tasks)
        {
            TaskList.Add(new Task(task, TaskStatus.Todo));
        }
    }

    /// <summary>
    /// Removes an arbitrary amount of tasks by indices.
    /// </summary>
    /// <param name="indices">The tasks to remove given their indices.</param>
    public void DeleteTask(params int[] indices)
    {
        var count = 0;
        foreach (var index in indices)
        {
            // Ensure index is in range
            if (index >= TaskList.Count)
                throw new ArgumentOutOfRangeException(nameof(indices), "Task index to remove was out of range.");

            // When an element from a list is deleted all
            // index positions are shifted by the current
            // iteration - 1
            TaskList.RemoveAt(index - count);
            count++;
        }
    }

    /// <summary>
    /// Updates the content of the indexed task.
    /// </summary>
    /// <param name="index">The index of the task.</param>
    /// <param name="newContent">The new content of the task.</param>
    public void UpdateTask(int index, string newContent)
    {
        // Validate arguments
        if (string.IsNullOrWhiteSpace(newContent))
            throw new ArgumentException("New content cannot be empty.", nameof(newContent));
        if (index < 0 || index >= TaskList.Count)
            throw new ArgumentOutOfRangeException(nameof(index), "Index is out of range.");

        TaskList[index] = new Task(newContent, TaskList[index].Status);
    }

    /// <summary>
    /// Sets the status of a task at the given index.
    /// </summary>
    /// <param name="index">The index of the task.</param>
    /// <param name="status">The new status of the task.</param>
    public void SetStatus(int index, TaskStatus status)
    {
        TaskList[index] = new Task(TaskList[index].Content, status);
    }

    /// <summary>
    /// Marks the task to be `todo` at the given index.
    /// </summary>
    /// <param name="index">The index of the task.</param>
    public void MarkTodo(int index)
    {
        SetStatus(index, TaskStatus.Todo);
    }

    /// <summary>
    /// Marks the task to be `inprogress` at the given index.
    /// </summary>
    /// <param name="index">The index of the task.</param>
    public void MarkInProgress(int index)
    {
        SetStatus(index, TaskStatus.Inprogress);
    }

    /// <summary>
    /// Marks the task to be `done` at the given index.
    /// </summary>
    /// <param name="index">The index of the task.</param>
    public void MarkDone(int index)
    {
        SetStatus(index, TaskStatus.Done);
    }

    /// <summary>
    /// Returns a list containing only the contents portion of all tasks.
    /// </summary>
    /// <returns>A contents list.</returns>
    public List<string> GetTaskContents()
    {
        return TaskList.Select(task => task.Content).ToList();
    }

    /// <summary>
    /// Displays all the tasks to do.
    /// </summary>
    public void DisplayTasks()
    {
        for (var i = 0; i < TaskList.Count; i++)
        {
            Console.WriteLine($"{i + 1}) {TaskList[i].Content} [{TaskList[i].Status}]");
        }
    }
};
