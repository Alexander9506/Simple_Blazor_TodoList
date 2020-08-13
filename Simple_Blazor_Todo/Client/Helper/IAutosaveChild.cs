using Microsoft.AspNetCore.Components;
using Simple_Blazor_Todo.Client.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Simple_Blazor_Todo.Client.Helper
{
    public interface IAutosaveChild<T>
    {
        public Action<T> AddChangedEntity { get; set; }
        
        [CascadingParameter]
        public AutosaveComponent<T> Parent { get; set; }
    }
}
