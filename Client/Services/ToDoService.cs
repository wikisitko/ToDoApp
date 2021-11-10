using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoApp.Shared;
using Blazored.Toast.Services;
using System.Net.Http;
using System.Net.Http.Json;

namespace ToDoApp.Client.Services
{
    public class ToDoService : IToDoService
    {
        private readonly IToastService toastService;
        private readonly HttpClient http;

        public event Action OnToDoSLoaded;

        public List<ToDo> myTasks { get; set; } = new List<ToDo>();

        public ToDoService(IToastService toastService, HttpClient http)
        {
            this.toastService = toastService;
            this.http = http;
        }
        public async Task LoadTasksAsync()
        {
            myTasks = await http.GetFromJsonAsync<List<ToDo>>("api/ToDo/tasks");
            OnToDoSLoaded?.Invoke();
        }
        public async Task AddTask(ToDoForm task)
        {
            var response = await http.PostAsJsonAsync("api/ToDo", task);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                toastService.ShowSuccess($"Task added!", "Great!");
                await GetTasks();
            }
        }

        public async Task GetTasks()
        {
            myTasks = await http.GetFromJsonAsync<List<ToDo>>("api/ToDo/tasks"); //wysyla zapytanie na backend w celu pobrania zadan
            OnToDoSLoaded?.Invoke();
        }

        public async Task DeleteTask(int taskId)
        {
            var result = await http.DeleteAsync($"api/ToDo/task/{taskId}");
            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                toastService.ShowSuccess("Task removed!", "Success");
                await LoadTasksAsync();
            }
            else
            {
                toastService.ShowError(await result.Content.ReadAsStringAsync(), "Error");
            }
        }

        public async Task TaskDone(int taskId)
        {
            var result = await http.PutAsJsonAsync("api/ToDo/task-done/", taskId); //put czy post
            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                toastService.ShowSuccess("Task done", "Success");
                await LoadTasksAsync();
            }
            else
            {
                toastService.ShowError(await result.Content.ReadAsStringAsync(), "Error");
            }
        }
    }
}
