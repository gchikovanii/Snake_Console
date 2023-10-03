using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake.Shared
{
    public struct Pixel
    {
        public Pixel(int x, int y, ConsoleColor color)
        {
            X = x;
            Y = y;
            Color = color;
        }

        public int X { get; set; }
        public int Y { get; set; }
        public ConsoleColor Color { get; set; }

        private const int _pixelSize = 3;
        private const char BorderSymbol = '█';

        public void DrawPixel()
        {
            Console.ForegroundColor = Color;
            for (int i = 0; i < _pixelSize; i++)
            {
                for (int j = 0; j < _pixelSize; j++)
                {
                    Console.SetCursorPosition(X * _pixelSize + i, Y * _pixelSize + j);
                    Console.Write(BorderSymbol);
                }
            }
        }
        public void Clear()
        {
            for (int i = 0; i < _pixelSize; i++)
            {
                for (int j = 0; j < _pixelSize; j++)
                {
                    Console.SetCursorPosition(X * _pixelSize + i, Y * _pixelSize + j);
                    Console.WriteLine(' ');
                }
            }
        }

    }
}
