using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Simple_Blazor_Todo.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Simple_Blazor_Todo.Server.Repositories
{
    public class TodoRepository : ITodoRepository
    {
        private readonly EFContext _context;
        private readonly ILogger _logger;
        public IQueryable<TodoItem> TodoItems => _context.TodoItems;
        public IQueryable<TodoList> TodoLists => _context.TodoLists.Include(todoList => todoList.Todos);

        public TodoRepository(EFContext context, ILogger<TodoRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<bool> SaveTodoItemAsync(TodoItem item)
        {
            if(item != null)
            {
                try
                {
                    _context.Update(item);
                    await _context.SaveChangesAsync();
                    return true;
                }catch(Exception e)
                {
                    _logger.LogError(e, "TodoItem cannot be saved");
                }
            }
            return false;
        }

        public async Task<bool> DeleteTodoItemAsync(TodoItem item)
        {
            if (item != null)
            {
                try
                {
                    _context.Remove(item);
                    await _context.SaveChangesAsync();
                    return true;
                }
                catch (Exception e)
                {
                    _logger.LogError(e, "TodoItem cannot be deleted");
                }
            }
            return false;
        }

        public async Task<bool> SaveTodoItemsAsync(IEnumerable<TodoItem> todos)
        {
            if (todos != null)
            {
                try
                {
                    _context.UpdateRange(todos);
                    await _context.SaveChangesAsync();
                    return true;
                }
                catch (Exception e)
                {
                    _logger.LogError(e, "TodoItems cannot be saved");
                }
            }
            return false;
        }

        public async Task<bool> SaveTodoListAsync(TodoList list)
        {
            if(list != null)
            {
                try
                {
                    _context.Update(list);
                    await _context.SaveChangesAsync();
                    return true;
                }
                catch (Exception e)
                {

                    _logger.LogError(e, "TodoList cannot be saved");
                }

            }
            return false;
        }

        public async Task<bool> DeleteTodoListAsync(TodoList list)
        {
            if (list != null)
            {
                try
                {
                    _context.Remove(list);
                    await _context.SaveChangesAsync();
                    return true;
                }
                catch (Exception e)
                {

                    _logger.LogError(e, "TodoList cannot be saved");
                }

            }
            return false;
        }
    }
}
