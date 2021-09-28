using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoApp.Server.Data;
using ToDoApp.Shared;

namespace ToDoApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController : ControllerBase
    {
        private readonly DataContext dataContext;

        public ToDoController(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        [HttpPost]
        public async Task<IActionResult> AddItem(ToDo toDo)
        {
            await dataContext.AddAsync(toDo); //co z ta lista na froncie?
            await dataContext.SaveChangesAsync();
            var list = await dataContext.Tasks.ToListAsync();
            return Ok(list);
        }

        [HttpGet]
        public async Task<IActionResult> GetItems()
        {
            var items = await dataContext.Tasks.ToListAsync();
            return Ok(items);
        }
    }
}
