using TaskManager;

namespace TaskTracker.UnitTests;

public class TestTasks
{
    [Fact]
    public void CanAddTask()
    {
        var task = new Tasks();

        task.AddTask("x");

        var taskContents = task.GetTaskContents();
        Assert.Contains("x", taskContents);
    }

    [Fact]
    public void CanAddMultipleTask()
    {
        var task = new Tasks();

        task.AddTask("x", "y");

        var taskContents = task.GetTaskContents();
        Assert.Contains("x", taskContents);
        Assert.Contains("y", taskContents);
    }

    [Fact]
    public void CanRemoveTaskByIndex()
    {
        var task = new Tasks();

        task.AddTask("x");
        task.AddTask("y");
        task.AddTask("z");

        task.RemoveTaskByIndex(1); // Removes y

        var taskContents = task.GetTaskContents();
        Assert.DoesNotContain("y", taskContents);
    }

    [Fact]
    public void CanRemoveMultipleTaskByIndex()
    {
        var task = new Tasks();

        task.AddTask("x");
        task.AddTask("y");
        task.AddTask("z");

        task.RemoveTaskByIndex(1, 2); // Removes y and z

        var taskContents = task.GetTaskContents();
        Assert.DoesNotContain("y", taskContents);
        Assert.DoesNotContain("z", taskContents);
    }

    [Fact]
    public void CanRemoveTaskByName()
    {
        var task = new Tasks();

        task.AddTask("x");
        task.AddTask("y");
        task.AddTask("z");

        task.RemoveTaskByName("z");

        var taskContents = task.GetTaskContents();
        Assert.DoesNotContain("z", taskContents);
    }

    [Fact]
    public void CanRemoveMultipleTaskByName()
    {
        var task = new Tasks();

        task.AddTask("x");
        task.AddTask("y");
        task.AddTask("z");

        task.RemoveTaskByName("x");
        task.RemoveTaskByName("z");

        var taskContents = task.GetTaskContents();
        Assert.DoesNotContain("x", taskContents);
        Assert.DoesNotContain("z", taskContents);
    }

    [Fact]
    public void DisplayTasksOutputsAllTasks()
    {
        var task = new Tasks();
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
