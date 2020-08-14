using System;
using System.Collections.Generic;
using System.Text;

namespace Simple_Blazor_Todo.Shared
{
    public class TodoList
    {
        public int TodoListId { get; set; }
        public string Titel { get; set; }
        public DateTime CreatedAt { get; set; }
        public IList<TodoItem> Todos { get; set; }
    }
}
