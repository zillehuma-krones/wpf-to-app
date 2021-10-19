using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp.Models;
using WpfApp.Services;

namespace WpfApp.ViewModels
{
   public class ToDoItemViewModel
    {
        private readonly ITodoItemService _todoItemService;
            private readonly BindingList<TODOItem> _allTodos;

public TODOItem TodoItem { get; }

        public string Name
        {
            get { return TodoItem.Name; }
            set { TodoItem.Name = value; }
        }

        public bool IsDone
        {
            get { return TodoItem.IsDone; }
            set {
                TodoItem.IsDone = value;
                _todoItemService.WriteToDoItems(_allTodos);
            }
        }


        public DateTime Datum
        {
            get { return TodoItem.Datum; }
            set { TodoItem.Datum = value; }
        }


        public ToDoItemViewModel(
            TODOItem todoItem, 
            ITodoItemService todoItemService, 
            BindingList<ToDoItemViewModel> alltodos)
        {
            TodoItem = todoItem;
            _todoItemService = todoItemService;
            _allTodos =new BindingList<TODOItem>(alltodos.Select(vm => vm.TodoItem).ToList());
        }
    }
}
