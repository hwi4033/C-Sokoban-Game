using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace C__Sokoban
{
    internal class Player
    {
        private int x;
        private int y;
        private int moveCount = 0;
        private int crashbox = 0;
        private string shape;

        public Player(int x, int y, string shape)
        {
            this.x = x;
            this.y = y;
            this.shape = shape;
        }

        public int X
        {
            get { return x; }
            set { x = value; }
        }
        public int Y
        {
            get { return y; }
            set { y = value; }
        }
        public int MoveCount
        {
            get { return moveCount; }
            set { moveCount = value; }
        }
        public int Crashbox
        {
            get { return crashbox; }
            set { crashbox = value; }
        }
        public string Shape
        {
            get { return shape; }
            set { shape = value; }
        }

        public void Move(int [,] stage, ConsoleKeyInfo key, int crashbox)
        {
            switch (key.Key)
            {
                case ConsoleKey.UpArrow:
                    if (stage[y - 1, x / 2] != 1)
                    {
                        y--;
                        moveCount++;
                        if(crashbox == 1)
                        {
                            y++;
                        }
                    }
                    break;
                case ConsoleKey.LeftArrow:
                    if (stage[y, x / 2 - 1] != 1)
                    {
                        x -= 2;
                        moveCount++;
                        if (crashbox == 2)
                        {
                            x += 2;
                        }
                    }
                    break;
                case ConsoleKey.RightArrow:
                    if (stage[y, x / 2 + 1] != 1)
                    {
                        x += 2;
                        moveCount++;
                        if (crashbox == 3)
                        {
                            x -= 2;
                        }
                    }
                    break;
                case ConsoleKey.DownArrow:
                    if (stage[y + 1, x / 2] != 1)
                    {
                        y++;
                        moveCount++;
                        if (crashbox == 4)
                        {
                            y--;
                        }
                    }
                    break;
            }
        }

        public void Collider(int[,] stage, int bx, int by, ref int pushbox)
        {
            if (y - 1 == by && x / 2 == bx / 2)
            {
                if (stage[by - 1, bx / 2] == 1)
                {
                    pushbox = 0;
                    crashbox = 1;
                }
                else pushbox = 1;
            }
            else if (y == by && x / 2 - 1 == bx / 2)
            {
                if (stage[by, bx / 2 - 1] == 1)
                {
                    pushbox = 0;
                    crashbox = 2;
                }
                else pushbox = 2;
            }
            else if (y == by && x / 2 + 1 == bx / 2)
            {
                if (stage[by, bx / 2 + 1] == 1)
                {
                    pushbox = 0;
                    crashbox = 3;
                }
                else pushbox = 3;
            }
            else if (y + 1 == by && x / 2 == bx / 2)
            {
                if (stage[by + 1, bx / 2] == 1)
                {
                    pushbox = 0;
                    crashbox = 4;
                }
                else pushbox = 4;
            }
        }
    }
}
