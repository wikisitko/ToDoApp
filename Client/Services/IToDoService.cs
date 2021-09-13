using System.Collections.Generic;
using ToDoApp.Shared;

namespace ToDoApp.Client.Services
{
    public interface IToDoService
    {
        IReadOnlyList<string> CategoryList { get; }
        List<ToDo> myTasks { get; }

        void AddTask(ToDo task);
    }
}