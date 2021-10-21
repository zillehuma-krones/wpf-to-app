﻿using Newtonsoft.Json;
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
   public class TodoItemService : ITodoItemService
    {
        private const string filePath = @"C:\Prj\TestProjekte\WPFLearning\WpfApp\TODOs.json";

        public BindingList<TODOItem> ReadToDoItems()
        {
            if (File.Exists(filePath))
            {
                var toDoItems = new BindingList<TODOItem>();

                var jsonOutput = JsonConvert.DeserializeObject<BindingList<TODOItem>>(File.ReadAllText(filePath));

                toDoItems = jsonOutput;

                return toDoItems;
            }


            return null;
        }

        public void WriteToDoItems( BindingList<TODOItem> todoItems)
        {
            if (File.Exists(filePath))
            {
                var jsonInput = JsonConvert.SerializeObject(todoItems, Formatting.Indented);

                File.WriteAllText(filePath, jsonInput);
            }
            
        }
    }
}
