using System;
using System.Linq;


namespace DatesAndHolidays_EntityVersion.Menu
{
    using Exceptions;
    using System.Threading;

    class ProgressBar
    {
        public int x;
        public int y;
        private int len { get; set; }


        private string barFull;
        private string barEmpty;

        public DateTime currentDate { get; set; }
        private static DateTime startYear = new DateTime(DateTime.Now.Year, 1, 1);


        public ProgressBar(int x, int y, int len)
        {
            this.y = y;
            this.x = x;
            this.len = len;
            this.currentDate = DateTime.Now;
        }


        private void drawDate()
        {
            Console.SetCursorPosition(x, y + 2);
            Console.Write(currentDate.Date.ToString().Substring(0, 10));
        }


        private void drawPercent()
        {
            Console.Write((currentDate - startYear).Days * 100 / 364);
            Console.Write("%  ");
        }


        private int getLen(DateTime date)
        {
            return (date - startYear).Days * len / 364;
        }


        public void addDays(int number)
        {
            if (currentDate.AddDays(number).Year != currentDate.Year)
            {
                throw new DateOutOfRangeException("В году всего 365 дней!!!");
            }

            currentDate = currentDate.AddDays(number);
        }


        public void drawWarning(string Message)
        {
            Console.SetCursorPosition(this.x + 20, this.y + 2);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(Message);
            Console.ForegroundColor = ConsoleColor.White;
            Thread.Sleep(1000);
            Console.SetCursorPosition(this.x + 20, this.y + 2);
            Console.Write(String.Concat(Enumerable.Repeat(" ", len - Message.Length)));
        }


        public void show()
        {
            Console.SetCursorPosition(this.x, this.y);

            this.barFull = String.Concat(Enumerable.Repeat("█", getLen(this.currentDate)));
            this.barEmpty = String.Concat(Enumerable.Repeat("_", len - getLen(this.currentDate)));

            Console.Write(barFull);
            Console.Write(barEmpty);

            drawPercent();
            drawDate();
        }
    }
}
