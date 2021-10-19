using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp.Services
{
    public class DateTimeService: IDateTimeService
    {
        public DateTime GetDatum()
        {
            return DateTime.Now;
        }
    }
}
