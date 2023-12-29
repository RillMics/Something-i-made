using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphics
{
    class vec2
    {
        public int x;
        public int y;
        public vec2 range(vec2 first, vec2 second)
        {
            return first - second;
        }
        public static vec2 operator +(vec2 first, vec2 second)
        {
            return new vec2(first.x + second.x, first.y + second.y);
        }
        public static vec2 operator -(vec2 first, vec2 second)
        {
            return new vec2(first.x - second.x, first.y - second.y);
        }
        public static vec2 operator *(vec2 first, vec2 second)
        {
            return new vec2(first.x * second.x, first.y * second.y);
        }
        public static vec2 operator /(vec2 first, vec2 second)
        {
            return new vec2(first.x / second.x, first.y / second.y);
        }
        public static vec2 operator ^(vec2 first, vec2 second)
        {
            return new vec2(first.x ^ second.x, first.y ^ second.y);
        }
        public vec2(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }



    class screen
    {
        public static int height = 30;
        public static int width = 120;
        public static char[] ChScreen = new char[width * height + 1];

        public static int CalcCoord(int x, int y)
        {
            return (x * width) + y;
        }
        public static void CalcPix(int x, int y)
        {
            ChScreen[CalcCoord(x, y)] = '#';
        }
        public static void CalcPix(int x, int y, char symbol)
        {
            ChScreen[CalcCoord(x, y)] = symbol;
        }
        public static void CalcPix(vec2 coord)
        {
            ChScreen[CalcCoord(coord.x, coord.y)] = '#';
        }
        public static void CalcPix(vec2 coord, char symbol)
        {
            ChScreen[CalcCoord(coord.x, coord.y)] = symbol;
        }
        public static void Clear()
        {
            for (int i = 0; i <= width * height; i++)
            {
                ChScreen[i] = '\0';
            }
        }
        public static void ClearHalfUp()
        {
            for (int i = 0; i <= (width * height) / 2; i++)
            {
                ChScreen[i] = '\0';
            }
        }
        public static void ClearHalfDown()
        {
            for (int i = 0; i <= (width * height); i++)
            {
                if (i >= (width * height) / 2)
                {
                    ChScreen[i] = ChScreen[i];
                }
                else { if (i <= (width * height) / 2) { ChScreen[i] = '\0'; } }
            }
        }
        public static void CalcSqu(int x, int y, int size)
        {
            for (int i = 0; i <= size - 1; i++)
            {
                for (int j = 0; j <= size - 1; j++)
                {
                    CalcPix((i + x) / 2, j + y);
                }
            }
        }
        public void CalcSqu(int x, int y, int size, char symbol)
        {
            for (int i = 0; i <= size - 1; i++)
            {
                for (int j = 0; j <= size - 1; j++)
                {
                    CalcPix((i + x) / 2, j + y, symbol);
                }
            }
        }
        public void CalcSqu(vec2 coord, int size, char symbol)
        {
            for (int i = 0; i <= size - 1; i++)
            {
                for (int j = 0; j <= size - 1; j++)
                {
                    CalcPix((i + coord.x) / 2, j + coord.y, symbol);
                }
            }
        }
        public void CalcSqu(vec2 coord, vec2 size, char symbol)
        {
            for (int i = 0; i <= size.y - 1; i++)
            {
                for (int j = 0; j <= size.x - 1; j++)
                {
                    CalcPix((i + coord.x), j + coord.y, symbol);
                }
            }
        }
        public void Square(vec2 coord, int size, char symbol)
        {
            CalcSqu(coord, size, symbol);
        }
        public void Square(vec2 coord, vec2 size, char symbol)
        {
            CalcSqu(coord, size, symbol);
        }
        public void pixel(int x, int y)
        {
            CalcPix(x, y);
        }
        public void pixel(vec2 coord)
        {
            CalcPix(coord.x, coord.y);
        }
        public void pixel(int x, int y, char symbol)
        {
            CalcPix(x, y, symbol);
        }
        public void pixel(vec2 coord, char symbol)
        {
            CalcPix(coord.x, coord.y, symbol);
        }
        public char[] GetScreen()
        {
            return ChScreen;
        }
        public void setWindow(vec2 size)
        {
            width = size.x;
            height = size.y;
            Array.Resize(ref ChScreen, width * height);
            Console.SetWindowSize(size.x, size.y);
        }
        public void clr()
        {
            Clear();
        }
        public void Update()
        {
            Console.WriteLine(ChScreen);
        }
    }
}
