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
            var containsTask = task.TaskList.Where(task => task == "x");

            Assert.NotEmpty(containsTask);
        }
    }
}