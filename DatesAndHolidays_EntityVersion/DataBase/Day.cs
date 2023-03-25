using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatesAndHolidays_EntityVersion.DataBase
{
    class Day
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }

        public string Holidays { get; set; }
    }
}
