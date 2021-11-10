using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ToDoApp.Server.Data;
using ToDoApp.Shared;

namespace ToDoApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ToDoController : ControllerBase
    {
        private readonly DataContext dataContext;

        public ToDoController(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        private async Task<User> GetUser()
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var user = await dataContext.Users.FirstOrDefaultAsync(x => x.Id == userId);
            return user;
        }

        [HttpPost]
        public async Task<IActionResult> AddItem(ToDoForm toDo)
        {
            var user = await GetUser();
            var t = new ToDo
            {
                Category = toDo.Category,
                ShortDescription = toDo.ShortDescription,
                Priority = toDo.Priority,
                IfDone = toDo.IfDone,
                DueDate = toDo.DueDate,
                Description = toDo.Description,
                User = user
            };
            await dataContext.Tasks.AddAsync(t);
            await dataContext.SaveChangesAsync();
            return Ok(t.Id);
        }

        [HttpGet("tasks")]
        public async Task<IActionResult> GetItems()
        {
            var user = await GetUser();
            var tasks = await dataContext.Tasks.Where(x => x.User.Id == user.Id).ToListAsync();
            return Ok(tasks);
        }
        
        [HttpDelete("task/{id}")]
        public async Task<IActionResult> DeleteItem(int id)
        {
            //TODO: dodac walidacje czy zadanie nalezy do uzytkownika ktory robi zapytanie
            ToDo toDo = await dataContext.Tasks.FirstOrDefaultAsync(x => x.Id == id);
            if(toDo == null)
            {
                return NotFound("task not found");
            }
            
            dataContext.Remove(toDo);
            await dataContext.SaveChangesAsync();
            return Ok("Removed");
        }

        [HttpPut("task-done")]
        public async Task<IActionResult> ItemDone([FromBody]int id)
        {
            //TODO: dodac walidacje czy zadanie nalezy do uzytkownika ktory robi zapytanie
            ToDo toDo = await dataContext.Tasks.FirstOrDefaultAsync(x => x.Id == id);
            if (toDo == null)
            {
                return NotFound("task not found");
            }

            toDo.IfDone = true;
            await dataContext.SaveChangesAsync();
            return Ok("Done");
        }

    }
}
