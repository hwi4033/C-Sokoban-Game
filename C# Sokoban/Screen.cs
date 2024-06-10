using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace C__Sokoban
{
    internal class Screen
    {
        private readonly int width;
        private readonly int height;

        public Screen()
        {   
            width = 40;
            height = 20;

            Console.SetWindowSize(width, height);
            Console.CursorVisible = false;
            MainScreen();
            Console.Clear();
        }

        public void MainScreen()
        {
            bool enter = true;
            Console.SetCursorPosition(14, 7);
            Console.Write("Sokoban Game");
            Console.SetCursorPosition(14, 11);
            Console.Write("> 게임 시작");
            ConsoleKeyInfo key;

            while (enter)
            {
                key = Console.ReadKey();
                switch (key.Key)
                {
                    case ConsoleKey.Enter: enter = false;
                        break;
                    default: enter = true;
                        break;
                }
            }
        }
    }
}
