using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoApp.Shared;

namespace ToDoApp.Client.Services
{
    public interface IToDoService
    {
        IReadOnlyList<string> CategoryList { get; }
        List<ToDo> myTasks { get; }

        Task AddTask(ToDo task);
        Task GetTasks();
        event Action OnToDoSLoaded;
    }
}
