using Snake.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake.Helpers
{
    public static class FoodHelper
    {
        public static Pixel GenerateFood(Snakes snake,int MapWidth, int MapHeight)
        {
            Pixel jelly;
            Random random = new Random();
            do
            {
                jelly = new Pixel(random.Next(1, MapWidth - 3), random.Next(3, MapHeight - 3),ConsoleColor.Yellow);
            }
            while (snake.Head.X == jelly.X && snake.Head.Y == jelly.Y
            || snake.Body.Any(i => i.X == jelly.X && i.Y == jelly.Y));

            return jelly;
        }
    }
}
