using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DatesAndHolidays_EntityVersion.DataBase
{
    class DataManager
    {
        private MyDbContext db = new MyDbContext();


        public void addElement(Day day) 
        {
            db.Days.Add(day);
            db.SaveChanges();
        }


        public bool isEmpty() 
        {
            return db.Days.Count() == 0;
        }


        public Day getElement(DateTime date)
        {
            var day = db.Days.First(p => (p.Date.Month == date.Month && p.Date.Day == date.Day));
            return day;
        }


        public List<string> getHolidays(DateTime date)
        {
            var day = db.Days.FirstOrDefault(p => (p.Date.Month == date.Month && p.Date.Day == date.Day));
            return day.Holidays.Split(new char[] { '/' }).ToList();
        }
        

        public void clearData()
        {
            for (int i = 1; i <= db.Days.Count(); i++)
            {
                var day = db.Days.Find(i);
                db.Days.Remove(day);
            }
        }
    }
}
