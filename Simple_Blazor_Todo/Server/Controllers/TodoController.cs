using Simple_Blazor_Todo.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Simple_Blazor_Todo.Server.Repositories;

namespace Simple_Blazor_Todo.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TodoController : ControllerBase
    {
        private readonly ILogger<TodoController> logger;
        private readonly ITodoRepository _todoRepository;

        public TodoController(ILogger<TodoController> logger, ITodoRepository todoRepository)
        {
            this.logger = logger;
            this._todoRepository = todoRepository;
        }

        [HttpGet("GetTodos")]
        public IEnumerable<TodoItem> GetTodos()
        {
            IEnumerable<TodoItem> todoItems = _todoRepository.TodoItems.ToArray();
            return todoItems;
        }

        [HttpPost("UpdateTodos")]
        public async Task<IActionResult> UpdateTodos(IEnumerable<TodoItem> todos)
        {
            if(todos != null && todos.Count() > 0)
            {
                if (await _todoRepository.SaveTodoItemsAsync(todos))
                {
                    return Ok();
                }
            }
            return BadRequest();
        }
    }
}
