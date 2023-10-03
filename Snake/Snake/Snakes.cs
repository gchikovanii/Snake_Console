using Snake.Datas;
using Snake.Shared;

namespace Snake
{
    public class Snakes
    {
        public Pixel Head { get; set; }

        public Queue<Pixel> Body = new Queue<Pixel>();
        private readonly ConsoleColor _headColor;
        private readonly ConsoleColor _bodyColor;
        private int _bodyLength = 3;

        public Snakes(int initialX, int initialY, ConsoleColor headColor, ConsoleColor bodyColor,int bodyLength =3)
        {
            _headColor = headColor;
            _bodyColor = bodyColor;
            Head = new Pixel(initialX,initialY, _headColor);
            for (int i = _bodyLength; i >= 0; i--)
            {
                Body.Enqueue(new Pixel(Head.X - i - 1, initialY, _bodyColor));
            }
            DrawSnake();
        }
        public void DrawSnake()
        {
            Head.DrawPixel();
            foreach (var pix in Body)
            {
                pix.DrawPixel();
            }
        }
        public void Clear()
        {
            Head.Clear();
            foreach (var pix in Body)
            {
                pix.Clear();
            }
        }

        public void Move(Direction dir, bool eat = false)
        {
            Clear();
            Body.Enqueue(new Pixel(Head.X, Head.Y, _bodyColor));
            if (!eat)
                Body.Dequeue();
            Head = dir switch
            {
                Direction.Up => new Pixel(Head.X, Head.Y - 1, _headColor),
                Direction.Down => new Pixel(Head.X, Head.Y + 1, _headColor),
                Direction.Right => new Pixel(Head.X + 1, Head.Y, _headColor),
                Direction.Left => new Pixel(Head.X - 1, Head.Y, _headColor),
                _ => Head
            };
            DrawSnake();
        }
    }
}
