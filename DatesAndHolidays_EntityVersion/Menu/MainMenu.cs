using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatesAndHolidays_EntityVersion.Menu
{
    class MainMenu
    {
        public string Header { get; set; }
        public string SubTitle { get; set; }
        public string CursorText { get; set; }
        public ConsoleColor CursorColor { get; set; }
        public ConsoleColor HeaderColor { get; set; }
        public ConsoleColor ForeColor { get; set; }
        public ConsoleColor MenuItemColor { get; set; }
        public ConsoleColor SubTitleColor { get; set; }
        public List<string> content { get; set; }


        private List<MenuItem> menuItemList;

        private int cursor;
        private bool exit;


        public MainMenu(string cursorText = "->")
        {
            menuItemList = new List<MenuItem>();
            cursor = 0;

            this.CursorText = cursorText;
            CursorColor = ConsoleColor.Yellow;
            HeaderColor = ConsoleColor.Blue;
            ForeColor = ConsoleColor.White;
            MenuItemColor = ConsoleColor.White;
            SubTitleColor = ConsoleColor.White;
        }


        public void removeMenuItems()
        {
            menuItemList.Clear();
        }


        public bool addMenuItem(int id, string text, Action action)
        {
            // check if it dosen't already exists
            if (!menuItemList.Any(item => item.ID == id))
            {
                menuItemList.Add(new MenuItem(id, text, action));
                return true;
            }
            return false;
        }


        public void drawHeader()
        {
            Console.SetCursorPosition(0, 0);
            Console.ForegroundColor = HeaderColor;
            Console.WriteLine(Header);
            Console.ForegroundColor = ForeColor;
        }


        public void draw()
        {
            Console.WriteLine(SubTitle);

            for (int i = 0; i < menuItemList.Count; i++)
            {
                if (i == cursor)
                {
                    Console.ForegroundColor = CursorColor;
                    Console.Write(CursorText + " ");
                    Console.WriteLine(menuItemList[i].Text);
                    Console.ForegroundColor = ForeColor;
                    continue;
                }

                Console.Write(new string(' ', (CursorText.Length + 1)));
                Console.WriteLine(menuItemList[i].Text);
            }
        }


        public void drawContent()
        {
            Console.SetCursorPosition(42, 4);
            Console.Write("В ЭТОТ ДЕНЬ ОТМЕЧАЮТ");
            Console.SetCursorPosition(40, 6);

            int flag = 0;

            foreach (string item in content)
            {
                if (item.Length > 50)
                {
                    continue;
                }

                Console.Write($"> {item}");
                Console.Write(String.Concat(Enumerable.Repeat(" ", 50 - item.Length)));
                Console.SetCursorPosition(40, 6 + flag);
                flag += 2;

                if (flag == 20)
                {
                    break;
                }
            }
        }


        public void drawWithHeader()
        {
            drawHeader();
            draw();
        }


        public void clear()
        {
            Console.Clear();
        }


        public void clearWithoutHeader()
        {
            Console.Clear();
            drawHeader();
        }


        public virtual void hideMenu()
        {
            this.exit = true;
        }


        public void updateMenu()
        {
            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.UpArrow:
                    {
                        if (cursor > 0)
                        {
                            cursor--;
                            showMenu();
                        }
                    }
                    break;

                case ConsoleKey.DownArrow:
                    {
                        if (cursor < (menuItemList.Count - 1))
                        {
                            cursor++;
                            showMenu();
                        }
                    }
                    break;

                case ConsoleKey.Enter:
                    {
                        menuItemList[cursor].Action();
                        drawHeader();
                        Console.CursorVisible = true;
                    }
                    break;

                case ConsoleKey.Escape:
                    {
                        hideMenu();
                    }
                    break;
            }
        }

        public void showMenu()
        {
            Console.CursorVisible = false;
            drawWithHeader();
            drawContent();

            while (!exit)
            {
                updateMenu();
            }
        }
    }
}
