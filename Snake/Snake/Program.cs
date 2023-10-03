using Snake;
using Snake.BackgroundAggregate;
using Snake.Datas;
using Snake.Helpers;
using Snake.Shared;
using System.Diagnostics;
using static System.Console;

namespace SnakeGame
{
    internal class Program
    {
        private const int MapWidth = 30;
        private const int MapHeight = 20;
        private const int ScreenWidth = MapWidth * 3;
        private const int ScreenHeight = MapHeight * 3;
        private const int FrameInMs = 200;
        static void Main(string[] args)
        {
            SetWindowSize(ScreenWidth, ScreenHeight);
            SetBufferSize(ScreenWidth, ScreenHeight);
            CursorVisible = false;
            while (true)
            {
                StartGame();
                Thread.Sleep(1000);

                ReadKey();
            }
        }
        #region Starting Game 
        public static void StartGame()
        {
            Clear();
            Background.DrawBorder();

            int score = 0;
            //On low processors to hold same speed
            int lagInMs = 0;
            var snake = new Snakes(10, 5 , ConsoleColor.Green,ConsoleColor.Yellow);
            Pixel food = FoodHelper.GenerateFood(snake,MapWidth,MapHeight);
            food.DrawPixel();
            Stopwatch stopwatch = new Stopwatch();
            Direction currentMovement = Direction.Right;
            while (true)
            {
                stopwatch.Restart();
                //Snake cant move in different directions in one shot
                Direction oldMovement = currentMovement;
                while (stopwatch.ElapsedMilliseconds <= FrameInMs - lagInMs)
                {
                    if (currentMovement == oldMovement)
                        currentMovement = MovementHelper.ReadMovement(currentMovement);
                }
                stopwatch.Restart();
                if (snake.Head.X == food.X && snake.Head.Y == food.Y)
                {
                    snake.Move(currentMovement, true);

                    food = FoodHelper.GenerateFood(snake, MapWidth, MapHeight);
                    score++;
                    food.DrawPixel();
                    Task.Run(() => Beep(1800, 300));
                    if (score == 3)
                    {
                        break;
                    }
                }
                snake.Move(currentMovement);

                if (snake.Head.X == MapWidth - 1 || snake.Head.Y == MapHeight - 1 || snake.Head.Y == 0
                    || snake.Body.Any(i => i.X == snake.Head.X && i.Y == snake.Head.Y))
                    break;
                lagInMs = Convert.ToInt32(stopwatch.ElapsedMilliseconds);
            }
            snake.Clear();
            SetCursorPosition(ScreenWidth / 3, ScreenHeight / 2);
            if (score == 3)
            {
                snake.Clear();
                SetCursorPosition(ScreenWidth / 3, ScreenHeight / 2);
                WriteLine($"You have won the game! Your Total score was: {score}");
                Task.Run(() => Beep(400, 500));
            }
            else
            {
                snake.Clear();
                SetCursorPosition(ScreenWidth / 3, ScreenHeight / 2);
                WriteLine($"Game Over! Your Total score was: {score}");
                Task.Run(() => Beep(400, 500));
            }
        }
        #endregion
    }
}
