using System.Diagnostics;
using static System.Console;


namespace Snake_v1
{
    public class StartGameClass : DrawBorderClass
    {
        public const int ScreenWidth = MapWidth * 3;
        public const int ScreenHeight = MapHeight * 3;
        private const ConsoleColor HeadColor = ConsoleColor.Red;
        private const ConsoleColor BodyColor = ConsoleColor.Green;
        
        private const int FrameMs = 200;

        public static void StartGame()
        {
            Clear();
            DrawBorder();
            Direction currentMovement = Direction.Right;
            var snake = new Snake(10, 5, HeadColor, BodyColor);
            Pixel food = GenFood(snake);
            food.Draw();
            int score = 0;
            Stopwatch sw = new Stopwatch();
            while (true)
            {
                sw.Restart();
                Direction oldMovement = currentMovement;
                while (sw.ElapsedMilliseconds <= FrameMs)
                {
                    if (currentMovement == oldMovement)
                    {
                        currentMovement = ReadMovement(currentMovement);
                    }
                }

                if (snake.Head.X == food.X && snake.Head.Y == food.Y)
                {
                    snake.Move(currentMovement, true);

                    food = GenFood(snake);
                    food.Draw();

                    score++;
                }
                else
                {
                    snake.Move(currentMovement);
                }

                if (snake.Head.X == MapWidth - 1
                    || snake.Head.X == 0
                    || snake.Head.Y == MapHeight - 1
                    || snake.Head.Y == 0
                    || snake.Body.Any(b => b.X == snake.Head.X && b.Y == snake.Head.Y))
                    break;
            }
            snake.Clear();
            SetCursorPosition(ScreenWidth / 4, ScreenHeight / 2);
            WriteLine($"Game Over! Your score: {score}. Press ENTER to start a new game...");
        }

        static Direction ReadMovement(Direction currentDirection)
        {
            if (!KeyAvailable)
                return currentDirection;
            ConsoleKey key = ReadKey(true).Key;
            currentDirection = key switch
            {
                ConsoleKey.UpArrow when currentDirection != Direction.Down => Direction.Up,
                ConsoleKey.DownArrow when currentDirection != Direction.Up => Direction.Down,
                ConsoleKey.LeftArrow when currentDirection != Direction.Right => Direction.Left,
                ConsoleKey.RightArrow when currentDirection != Direction.Left => Direction.Right,
                _ => currentDirection
            };
            return currentDirection;
        }
    }
}
