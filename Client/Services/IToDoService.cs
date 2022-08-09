using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoApp.Shared;

namespace ToDoApp.Client.Services
{
    public interface IToDoService
    {
        List<ToDo> myTasks { get; }

        public Task AddTask(ToDoForm task);
        public Task GetTasks();
        event Action OnToDoSLoaded;
        public Task DeleteTask(int taskId);
        public Task LoadTasksAsync();
        public Task TaskDone(int taskId, bool done);

    }
}
