using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoApp.Shared;

namespace ToDoApp.Client.Services
{
    public class ToDoService : IToDoService
    {
        public List<ToDo> myTasks { get; } = new List<ToDo>();

        public IReadOnlyList<string> CategoryList { get; } = new List<string>() { "Work", "Learn", "Home", "Other" };

        public void AddTask(ToDo task)
        {
            myTasks.Add(task);
        }

    }
}
