using System;
using System.IO;
using Xunit;

namespace TaskTrackerTests
{
    public class TestTasks
    {
        [Fact]
        public void CanAddTask()
        {
            var task = new Tasks();

            task.AddTask("x");

            Assert.Contains("x", task.TaskList);
        }

        [Fact]
        public void CanAddMultipleTask()
        {
            var task = new Tasks();

            task.AddTask("x", "y");

            Assert.Contains("x", task.TaskList);
            Assert.Contains("y", task.TaskList);
        }

        [Fact]
        public void CanRemoveTaskByIndex()
        {
            var task = new Tasks();

            task.AddTask("x");
            task.AddTask("y");
            task.AddTask("z");

            task.RemoveTaskByIndex(1); // Removes y

            Assert.DoesNotContain("y", task.TaskList);
        }

        [Fact]
        public void CanRemoveMultipleTaskByIndex()
        {
            var task = new Tasks();

            task.AddTask("x");
            task.AddTask("y");
            task.AddTask("z");

            task.RemoveTaskByIndex(1, 2); // Removes y and z

            Assert.DoesNotContain("y", task.TaskList);
            Assert.DoesNotContain("z", task.TaskList);
        }

        [Fact]
        public void CanRemoveTaskByName()
        {
            var task = new Tasks();

            task.AddTask("x");
            task.AddTask("y");
            task.AddTask("z");

            task.RemoveTaskByName("z");

            Assert.DoesNotContain("z", task.TaskList);
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

            Assert.DoesNotContain("x", task.TaskList);
            Assert.DoesNotContain("z", task.TaskList);
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
}