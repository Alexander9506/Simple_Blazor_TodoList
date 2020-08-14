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

        [HttpGet("GetTodoList/{id?}")]
        public TodoList GetTodos(int id)
        {
            TodoList todoList = _todoRepository.TodoLists.FirstOrDefault(todoList => todoList.TodoListId == id);
            //Blazor javascript cannot handle Cyling references
            foreach (var todoItem in todoList.Todos)
            {
                todoItem.ParentList = null;
            }
            
            return todoList;
        }

        [HttpPost("UpdateTodoList")]
        public async Task<IActionResult> UpdateTodo(TodoList todoList)
        {
            if (todoList != null)
            {
                if (await _todoRepository.SaveTodoListAsync(todoList))
                {
                    return Ok(todoList.TodoListId);
                }
            }
            return BadRequest();
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

        [HttpPost("UpdateTodo")]
        public async Task<IActionResult> UpdateTodo(TodoItem todo)
        {
            if (todo != null)
            {
                if (await _todoRepository.SaveTodoItemAsync(todo))
                {
                    return Ok(todo.TodoItemID);
                }
            }
            return BadRequest();
        }

        [HttpPost("DeleteTodo")]
        public async Task<IActionResult> DeleteTodo(TodoItem todo)
        {
            if (todo != null)
            {
                if (await _todoRepository.DeleteTodoItemAsync(todo))
                {
                    return Ok(todo.TodoItemID);
                }
            }
            return BadRequest();
        }
    }
}
