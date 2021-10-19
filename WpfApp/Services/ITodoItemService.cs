using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp.Models;

namespace WpfApp.Services
{
     public interface ITodoItemService
    {
       BindingList<TODOItem> ReadToDoItems();

       void WriteToDoItems(BindingList<TODOItem> todoItems);
    }
}
