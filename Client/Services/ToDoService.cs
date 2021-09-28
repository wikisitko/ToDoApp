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

        public IReadOnlyList<string> CategoryList { get; } = new List<string>() { "Work", "Learn", "Home", "Other" };
        public ToDoService(IToastService toastService, HttpClient http)
        {
            this.toastService = toastService;
            this.http = http;
        }
        public async Task AddTask(ToDo task)
        {
            await http.PostAsJsonAsync("api/ToDo", task);
            toastService.ShowSuccess($"Task added!", "Great!");
            await GetTasks();
        }

        public async Task GetTasks()
        {
            myTasks = await http.GetFromJsonAsync<List<ToDo>>("api/ToDo"); //wysyla zapytanie na backend w celu pobrania zadan
            OnToDoSLoaded?.Invoke();
        }

    }
}
