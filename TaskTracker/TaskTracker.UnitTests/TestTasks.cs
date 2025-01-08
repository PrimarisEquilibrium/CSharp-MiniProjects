using TaskTracker.Tasks;

namespace TaskTracker.UnitTests;

public class TestTasks
{
    [Fact]
    public void CanAddTask()
    {
        var task = new TasksManager();

        task.AddTask("x");

        var taskContents = task.GetTaskContents();
        Assert.Contains("x", taskContents);
    }

    [Fact]
    public void CanAddMultipleTask()
    {
        var task = new TasksManager();

        task.AddTask("x", "y");

        var taskContents = task.GetTaskContents();
        Assert.Contains("x", taskContents);
        Assert.Contains("y", taskContents);
    }

    [Fact]
    public void CanRemoveTask()
    {
        var task = new TasksManager();

        task.AddTask("x");
        task.AddTask("y");
        task.AddTask("z");

        task.DeleteTask(1); // Removes y

        var taskContents = task.GetTaskContents();
        Assert.DoesNotContain("y", taskContents);
    }

    [Fact]
    public void CanRemoveMultipleTask()
    {
        var task = new TasksManager();

        task.AddTask("x");
        task.AddTask("y");
        task.AddTask("z");

        task.DeleteTask(1, 2); // Removes y and z

        var taskContents = task.GetTaskContents();
        Assert.DoesNotContain("y", taskContents);
        Assert.DoesNotContain("z", taskContents);
    }

    [Fact]
    public void CanUpdateTask()
    {
        var task = new TasksManager();

        task.AddTask("x");
        task.AddTask("y");
        task.AddTask("z");

        task.UpdateTask(0, "w");

        Assert.Equal("w", task.TaskList[0].Content);
    }

    [Fact]
    public void CanMarkTodo()
    {
        var task = new TasksManager();

        task.AddTask("x");

        task.MarkInProgress(0);
        task.MarkTodo(0);

        Assert.Equal(Tasks.TaskStatus.Todo, task.TaskList[0].Status);
    }

    [Fact]
    public void CanMarkInProgress()
    {
        var task = new TasksManager();

        task.AddTask("x");

        task.MarkInProgress(0);

        Assert.Equal(Tasks.TaskStatus.Inprogress, task.TaskList[0].Status);
    }

    [Fact]
    public void CanMarkDone()
    {
        var task = new TasksManager();

        task.AddTask("x");

        task.MarkDone(0);

        Assert.Equal(Tasks.TaskStatus.Done, task.TaskList[0].Status);
    }

    [Fact]
    public void DisplayTasksOutputsAllTasks()
    {
        var task = new TasksManager();
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);

        task.AddTask("x");
        task.AddTask("$c0nta1ns$");
        task.AddTask("z");
        task.DisplayTasks();

        var output = stringWriter.ToString().Trim();
        Assert.Contains("$c0nta1ns$", output);
    }
}
