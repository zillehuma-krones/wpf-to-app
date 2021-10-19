using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp.Models
{
    [Serializable]
   public class TODOItem
    {
        public TODOItem()
        {
        }

        public string Name { get; set; }
        public bool IsDone { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
