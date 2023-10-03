using Snake.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake.BackgroundAggregate
{
    public static class Background
    {

        private const int _mapWidth = 30;
        private const int _mapHeight = 20;
        private const ConsoleColor _color = ConsoleColor.Blue;
        public static void DrawBorder()
        {
            for (int i = 0; i < _mapWidth; i++)
            {
                new Pixel(i, 0, _color).DrawPixel();
                new Pixel(i, _mapHeight - 1, _color).DrawPixel();
            }
            for (int i = 0; i < _mapHeight; i++)
            {
                new Pixel(0, i, _color).DrawPixel();
                new Pixel(_mapWidth - 1, i, _color).DrawPixel();
            }
        }

    }
}
