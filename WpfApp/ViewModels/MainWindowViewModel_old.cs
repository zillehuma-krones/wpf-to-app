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

namespace WpfApp.ViewModels
{
   public class MainWindowViewModel_old
    {

        public const string FILE_PATH = "..\\..\\TODOs.json";

        public BindingList<TODOItem> ToDoItems { get; set; }
       
        public TODOItem SelectedTodoItem { get; set; }

        public AddNewTodoCommand AddNewToDoCommand { get; set; }

        public DeleteToDoCommand DeleteToDoCommand { get; set; }
        public string NewToDoName { get; set; }


        public MainWindowViewModel_old()
        {
            this.ToDoItems = this.ReadToDoItemsFromFile();
        
            AddNewToDoCommand = new AddNewTodoCommand(this);
            DeleteToDoCommand = new DeleteToDoCommand(this);

        }

        private BindingList<TODOItem> ReadToDoItemsFromFile()
        {
            var toDoItems = new BindingList<TODOItem>();

            var jsonOutput= JsonConvert.DeserializeObject<BindingList<TODOItem>>(File.ReadAllText(FILE_PATH));

            toDoItems = jsonOutput;

            return toDoItems;

        }


        public void NewTODOButton_Click()
        {
            if (!String.IsNullOrWhiteSpace(NewToDoName))
            {
                TODOItem todo = new TODOItem() { Name = NewToDoName, IsDone = false };
                ToDoItems.Add(todo);
            }
                       

            var jsonInput = JsonConvert.SerializeObject(ToDoItems, Formatting.Indented);

            File.WriteAllText(FILE_PATH, jsonInput);


        }

        public void DeleteTODOButton_Click()
        {  

            if(SelectedTodoItem!=null)
            {
                ToDoItems.Remove(SelectedTodoItem);
            }
            var jsonInput = JsonConvert.SerializeObject(ToDoItems, Formatting.Indented);

            File.WriteAllText(FILE_PATH, jsonInput);


        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

    }
}
