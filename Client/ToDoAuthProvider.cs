using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ToDoApp.Client.Services;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;

namespace ToDoApp.Client
{
    public class ToDoAuthProvider : AuthenticationStateProvider
    {
        private readonly ILocalStorageService localStorage;
        private readonly HttpClient httpClient;

        public ToDoAuthProvider(ILocalStorageService localStorage, HttpClient httpClient)
        {
            this.localStorage = localStorage;
            this.httpClient = httpClient;
        }

        //ta metoda stwierdza czy ma zalogowac uzytkownika czy nie
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var token = await localStorage.GetItemAsStringAsync("token");
            var identity = new ClaimsIdentity();
            httpClient.DefaultRequestHeaders.Authorization = null;

            if (!string.IsNullOrEmpty(token))
            {
                try
                {
                    identity = new ClaimsIdentity(ParseClaimsFormJwt(token), "jwt");
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                }
                catch (Exception)
                {
                    await localStorage.RemoveItemAsync("token");
                    identity = new ClaimsIdentity();
                }
            }

            var state = new AuthenticationState(new ClaimsPrincipal(identity));
            NotifyAuthenticationStateChanged(Task.FromResult(state));

            Console.WriteLine("OK: " + token);

            return state;
        }

        private byte[] Parse64BaseWithoutPadding(string base64)
        {
            switch (base64.Length % 4)
            {
                case 2:
                    base64 += "==";
                    break;
                case 3:
                    base64 += "=";
                    break;
            }
            return Convert.FromBase64String(base64);
        }
        private IEnumerable<Claim> ParseClaimsFormJwt(string jwt)
        {
            var payload = jwt.Split(".")[1];
            var jsonBytes = Parse64BaseWithoutPadding(payload);
            var keyValues = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonBytes);
            //var claims = new List<Claim>();
            //foreach (var item in keyValues)
            //{
            //    claims.Add(new Claim(item.Key, item.Value.ToString()));
            //}
            //return claims;
            foreach (var item in keyValues)
            {
                Console.WriteLine(item);
            }
            return keyValues.Select(x => new Claim(x.Key, x.Value.ToString()));
        }
    }
}
