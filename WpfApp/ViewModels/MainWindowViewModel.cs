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
    public class MainWindowViewModel
    {

        private readonly ITodoItemService _todoItemService;
        private readonly IDateTimeService _dateTimeService;

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

        public MainWindowViewModel(
            ITodoItemService todoItemService,
            IDateTimeService dateTimeService)
        {
            _todoItemService = todoItemService;
            _dateTimeService = dateTimeService;
            ToDoItems = new BindingList<ToDoItemViewModel>();
            var todoItems = _todoItemService.ReadToDoItems();

            if (todoItems != null)
                foreach (var item in todoItems)
                {
                    ToDoItems.Add(CreateToDoViewModel(item));
                }

            AddNewToDoCommand = new DelegateCommand(param => this.NewToDoNameIsNotEmpty, param => this.AddNewTodo());
            DeleteToDoCommand = new DelegateCommand(param => this.ToDoItemIsSelected, param => this.DeleteTodo());

        }

        private ToDoItemViewModel CreateToDoViewModel(TODOItem item)
        {
            return new ToDoItemViewModel(item, _todoItemService, ToDoItems);
        }


        public void AddNewTodo()
        {
            if (!String.IsNullOrWhiteSpace(NewToDoName))
            {
                TODOItem todo = new TODOItem()
                {
                    Name = NewToDoName,
                    TimeStamp = _dateTimeService.Now(),
                    IsDone = false
                };
                ToDoItems.Add(CreateToDoViewModel(todo));
            }

            var todoItems = ToDoItems.Select(vm => vm.TodoItem);
            this._todoItemService.WriteToDoItems(new BindingList<TODOItem>(todoItems.ToList()));


        }

        public void DeleteTodo()
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

