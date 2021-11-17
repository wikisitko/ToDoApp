using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoApp.Shared;

namespace ToDoApp.Client.Services
{
    interface IAuthService
    {
        Task<ServiceResponse<int>> Register(UserRegistration userRegistration);
        Task<ServiceResponse<string>> Login(UserLogin userLogin);
    }
}
