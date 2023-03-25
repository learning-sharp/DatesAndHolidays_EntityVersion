using System;
using System.Threading;

namespace DatesAndHolidays_EntityVersion
{
    using Scrapping;
    using Menu;
    using DataBase;
    using Exceptions;

    class Program
    {
        private static Parser parser = new Parser();
        private static UrlConstructor urlConstructor = new UrlConstructor();
        private static ProgressBar bar = new ProgressBar(5, Console.BufferHeight - 3, 100);
        private static MainMenu mainMenu = new MainMenu();
        private static DataManager dataManager = new DataManager();

        
        static void Main(string[] args)
        {
            mainMenu.Header = "DATES AND HOLIDAYS";
            
            mainMenu.content = dataManager.getHolidays(bar.currentDate);

            mainMenu.SubTitle = "---- Choose action ----";
            mainMenu.addMenuItem(0, "Add 10 days", () => addDays(10));
            mainMenu.addMenuItem(1, "Add 1 day", () => addDays(1));
            mainMenu.addMenuItem(2, "Subtract 1 day", () => addDays(-1));
            mainMenu.addMenuItem(3, "Subtract 10 days", () => addDays(-10));
            mainMenu.addMenuItem(4, "Exit", () => Environment.Exit(0));

            bar.show();
            mainMenu.showMenu();
            Console.ReadKey();
        }


        static void addDays(int number)
        {
            try
            {
                bar.addDays(number);
            }
            catch (DateOutOfRangeException Error)
            {
                bar.drawWarning(Error.Message);
                return;
            }

            mainMenu.content = dataManager.getHolidays(bar.currentDate);
            bar.show();
            mainMenu.showMenu();
        }


        static async void initData()
        {
            DateTime date = new DateTime(2022, 3, 28);

            for (int i = 0; i <= 365; i++) 
            {
                var url = urlConstructor.makeUrl(date);
                await parser.work(url);
                var content = parser.holidays;

                Console.WriteLine(date);

                var day = new Day()
                {
                    Date = date,
                    Holidays = parser.getHolidays()
                };

                dataManager.addElement(day);

                date = date.AddDays(1);

                Thread.Sleep(5000);
            }
        }
    }
}
