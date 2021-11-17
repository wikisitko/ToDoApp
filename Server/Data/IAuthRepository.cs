using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoApp.Shared;

namespace ToDoApp.Server.Data
{
    public interface IAuthRepository
    {
        Task<ServiceResponse<string>> Login(string email, string password);
        Task<ServiceResponse<int>> Register(User user, string password);
        Task<bool> UserExists(string email);
    }
}
