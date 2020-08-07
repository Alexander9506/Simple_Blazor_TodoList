using System;
using System.Collections.Generic;
using System.Text;

namespace Simple_Blazor_Todo.Shared
{
    public class TodoItem
    {
        public int TodoItemID { get; set; }
        public string Titel { get; set; }
        public string Description { get; set; }
        public bool IsDone { get; set; }
    }
}
