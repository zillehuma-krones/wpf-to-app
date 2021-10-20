using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp.Models;

namespace WpfApp.Services
{
   public class TodoItemService:ITodoItemService
    {
        private const string filePath = @"C:\Prj\TestProjekte\WPFLearning\WpfApp\TODOs.json";
        private const string jensFile = @"C:\temp\Zille\TODOs.json";

        public BindingList<TODOItem> ReadToDoItems()
        {
            if (File.Exists(jensFile))
            {
                var toDoItems = new BindingList<TODOItem>();

                var jsonOutput = JsonConvert.DeserializeObject<BindingList<TODOItem>>(File.ReadAllText(jensFile));

                toDoItems = jsonOutput;

                return toDoItems;
            }


            return null;
        }

        public void WriteToDoItems( BindingList<TODOItem> todoItems)
        {
            if (File.Exists(jensFile))
            {
                var jsonInput = JsonConvert.SerializeObject(todoItems, Formatting.Indented);

                File.WriteAllText(jensFile, jsonInput);
            }
            
        }
    }
}
