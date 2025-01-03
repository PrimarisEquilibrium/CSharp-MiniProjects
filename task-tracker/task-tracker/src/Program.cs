Console.WriteLine("Task Tracker CLI Application");

// while (true)
// {
//     Console.WriteLine("Enter a task to add to your list: ");
//     var newTask = Convert.ToString(Console.ReadLine());
//     if (newTask is not null)
//     {
//         taskList.Add(newTask);
//     }
// }

var tasks = new Tasks();
tasks.AddTask("Brush teeth", "Make breakfast", "Make bed");
tasks.RemoveTaskByName("Brush teeth");
tasks.RemoveTaskByIndex(0);
tasks.DisplayTasks();