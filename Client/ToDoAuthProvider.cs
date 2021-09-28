using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ToDoApp.Client.Services;

namespace ToDoApp.Client
{
    public class ToDoAuthProvider : AuthenticationStateProvider
    {
        private readonly ILocalStorageService localStorage;
        private readonly IToDoService toDoService;

        public ToDoAuthProvider(ILocalStorageService localStorage, IToDoService toDoService)
        {
            this.localStorage = localStorage;
            this.toDoService = toDoService;
        }

        //ta metoda stwierdza czy ma zalogowac uzytkownika czy nie
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var state = new AuthenticationState(new ClaimsPrincipal()); //uzytkownik nieuwierzytelniony

            if (await localStorage.GetItemAsync<bool>("isAuth"))
            {
                //to jest stworzony na stale zalogowany uzytkownik
                var identity = new ClaimsIdentity(new[]
                {
                new Claim(ClaimTypes.Name, "Wiki"),
                new Claim(ClaimTypes.Email, "wiki@gmail.com"),
                }, "test identity");
                state = new AuthenticationState(new ClaimsPrincipal(identity));
                await toDoService.GetTasks();
            }

            NotifyAuthenticationStateChanged(Task.FromResult(state));
            return state;
        }
    }
}
