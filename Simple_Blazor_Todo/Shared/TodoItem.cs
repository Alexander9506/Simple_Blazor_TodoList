using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Simple_Blazor_Todo.Shared
{
    public class TodoItem
    {
        public int TodoItemID { get; set; }
        public string Titel { get; set; }
        public string Description { get; set; }

        [NotMapped]
        public bool IsDone {
            get => DoneAt != null;
            set => DoneAt = (value ? (DateTime?)DateTime.Now : null);
        }

        public DateTime? DoneAt { get; set;}

        public IEnumerable<TodoItem> ChildItems { get; set; }
        //public TodoItem ParentItem { get; set; } => cirular references in blazor Text.JSON are available in the newest prerelease version
    }
}
