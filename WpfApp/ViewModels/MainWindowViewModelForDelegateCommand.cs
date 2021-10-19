using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfApp.Models;
using WpfApp.Commands;
using Newtonsoft.Json;
using WpfApp.Services;

namespace WpfApp.ViewModels
{
    public class MainWindowViewModelForDelegateCommand
    {
       
        private ITodoItemService _todoItemService;
        //private IDateTimeService dateTimeService;

        public BindingList<ToDoItemViewModel> ToDoItems { get; set; }

        public ToDoItemViewModel SelectedTodoItem { get; set; }

        public ICommand AddNewToDoCommand { get; set; }

        public ICommand DeleteToDoCommand { get; set; }

        public string NewToDoName { get; set; }
        public bool NewToDoNameIsNotEmpty
        {
            get
            {
                return this.NewToDoName != null && !String.IsNullOrWhiteSpace(this.NewToDoName);
            }
        }
        public bool ToDoItemIsSelected
        {
            get
            {
                return this.SelectedTodoItem != null;
            }
        }

        public MainWindowViewModelForDelegateCommand(ITodoItemService todoItemService)
        {
            _todoItemService = todoItemService;
            ToDoItems = new BindingList<ToDoItemViewModel>();
            var todoItems = _todoItemService.ReadToDoItems();

            if(todoItems!=null)
            foreach(var item in todoItems)
            {
                ToDoItems.Add(CreateToDoViewModel(item));
            }

            AddNewToDoCommand = new DelegateCommand(param =>this.NewToDoNameIsNotEmpty, param=>this.NewTODOButton_Click());
             DeleteToDoCommand = new DelegateCommand(param =>this.ToDoItemIsSelected, param=>this.DeleteTODOButton_Click());

        }

        private ToDoItemViewModel CreateToDoViewModel(TODOItem item)
        {
            return new ToDoItemViewModel(item, _todoItemService, ToDoItems);
        }


        public void NewTODOButton_Click()
        {
            if (!String.IsNullOrWhiteSpace(NewToDoName))
            {
                TODOItem todo = new TODOItem() { Name = NewToDoName, Datum=DateTime.Now, IsDone = false };
                ToDoItems.Add(CreateToDoViewModel(todo));
            }

            var todoItems = ToDoItems.Select(vm => vm.TodoItem);
            this._todoItemService.WriteToDoItems(new BindingList<TODOItem>(todoItems.ToList()));


        }

        public void DeleteTODOButton_Click()
        {
            if (SelectedTodoItem != null)
            {
                ToDoItems.Remove(SelectedTodoItem);
            }

            var todoItems = ToDoItems.Select(vm => vm.TodoItem);
            this._todoItemService.WriteToDoItems(new BindingList<TODOItem>(todoItems.ToList()));


        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

    }
}

