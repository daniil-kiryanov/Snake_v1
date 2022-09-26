namespace Snake_v1
{
    public class Snake
    {
        private readonly ConsoleColor headColor;
        private readonly ConsoleColor bodyColor;
        public Queue<Pixel> Body { get; } = new Queue<Pixel>();
        public Pixel Head { get; private set; }

        public Snake(int initialX, int initialY, ConsoleColor headColor, ConsoleColor bodyColor, int bodyLenght = 3)
        {
            this.headColor = headColor;
            this.bodyColor = bodyColor;

            Head = new Pixel(initialX, initialY, headColor);

            for (int i = bodyLenght; i >= 0; i--)
            {
                Body.Enqueue(new Pixel(Head.X - i - 1, initialY, bodyColor));
            }
            Draw();

        }
              

        public void Move(Direction direction, bool eat = false)
        {
            Clear();
            Body.Enqueue(new Pixel(Head.X, Head.Y, bodyColor));
            if (!eat) Body.Dequeue();//if eat = true, not deqeue
            Head = direction switch
            {
                Direction.Right => new Pixel(Head.X + 1, Head.Y, headColor),
                Direction.Left => new Pixel(Head.X - 1, Head.Y, headColor),
                Direction.Up => new Pixel(Head.X, Head.Y - 1, headColor),
                Direction.Down => new Pixel(Head.X, Head.Y + 1, headColor),
                _ => Head
            };
            Draw();
        }

        public void Draw()
        {
            Head.Draw();
            foreach (Pixel pixel in Body)
            {
                pixel.Draw();
            }
        }

        public void Clear()
        {
            Head.Clear();
            foreach (Pixel pixel in Body)
            {
                pixel.Clear();
            }
        }

    }
}
