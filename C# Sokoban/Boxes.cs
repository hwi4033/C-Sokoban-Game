using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace C__Sokoban
{
    internal class Boxes
    {
        private int x;
        private int y;
        private string shape;

        public Boxes(int x, int y, string shape)
        {
            this.x = x;
            this.y = y;
            this.shape = shape;
        }
        public Boxes(Boxes boxes)
        {
            x = new int();
            y = new int();
            shape = boxes.shape;
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
        public string Shape
        {
            get { return shape; }
            set { shape = value; }
        }

        public void BoxMove(int[,] stage, int px, int py, int pushbox, int collbox)
        {
            switch (pushbox)
            {
                case 1:
                    if (y == py && x / 2 == px / 2)
                    {
                        y--;
                        if (collbox == 1)
                        {
                            y++;
                        }
                    }
                    break;
                case 2:
                    if (y == py && x / 2 == px / 2)
                    {
                        x -= 2;
                        if (collbox == 2)
                        {
                            x += 2;
                        }    
                    }
                    break;
                case 3:
                    if (y == py && x / 2 == px / 2)
                    {
                        x += 2;
                        if (collbox == 3)
                        {
                            x -= 2;
                        }
                    }
                    break;
                case 4:
                    if (y == py && x / 2 == px / 2)
                    {
                        y++;
                        if (collbox == 4)
                        {
                            y--;
                        }
                    }
                    break;
                default:
                    break;
            }
        }

        public void Collider(int[,] stage, int bx, int by, ref int collbox)
        {
            if (stage[y - 1, x / 2] == stage[by, bx / 2])
            {
                collbox = 1;
            }
            else if (stage[y, x / 2 - 1] == stage[by, bx / 2])
            {
                collbox = 2;
            }
            else if (stage[y, x / 2 + 1] == stage[by, bx / 2])
            {
                collbox = 3;
            }
            else if (stage[y + 1, x / 2] == stage[by, bx / 2])
            {
                collbox = 4;
            }
            else collbox = 0;
        }
    }
}
