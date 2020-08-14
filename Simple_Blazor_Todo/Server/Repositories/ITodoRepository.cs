using Simple_Blazor_Todo.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Simple_Blazor_Todo.Server.Repositories
{
    public interface ITodoRepository
    {
        IQueryable<TodoItem> TodoItems { get; }
        IQueryable<TodoList> TodoLists { get; }

        Task<bool> SaveTodoItemAsync(TodoItem item);
        Task<bool> DeleteTodoItemAsync(TodoItem item);
        Task<bool> SaveTodoItemsAsync(IEnumerable<TodoItem> todos);

        Task<bool> SaveTodoListAsync(TodoList list);
        Task<bool> DeleteTodoListAsync(TodoList list);
    }
}
