using System.Diagnostics;
using static System.Console;
namespace Snake_v1;
class Program
{
    private const int MapWidth = 30;
    private const int MapHeight = 20;
    private const int ScreenWidth = MapWidth * 3;
    private const int ScreenHeight = MapHeight * 3;
    private const ConsoleColor BorderColor = ConsoleColor.Gray;
    private const ConsoleColor HeadColor = ConsoleColor.Red;
    private const ConsoleColor BodyColor = ConsoleColor.Green;
    private const int FrameMs = 200;
    static void Main()
    {
        SetWindowSize(ScreenWidth, ScreenHeight);
        SetBufferSize(ScreenWidth, ScreenHeight);
        CursorVisible = false;
        DrawBorder();
        Direction currentMovement = Direction.Right;
        var snake = new Snake(10, 5, HeadColor, BodyColor);
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
            snake.Move(currentMovement);
            if (snake.Head.X == MapWidth - 1
                || snake.Head.X == 0
                || snake.Head.Y == MapHeight - 1
                || snake.Head.Y == 0
                || snake.Body.Any(b => b.X == snake.Head.X && b.Y == snake.Head.Y))
                break;
        }
        snake.Clear();
        SetCursorPosition(ScreenWidth / 3, ScreenHeight / 2);
        WriteLine("GameOver");
        ReadKey();
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

    static void DrawBorder()
    {
        for (int i = 0; i < MapWidth; i++) //horizontal border
        {
            new Pixel(i, 0, BorderColor).Draw();
            new Pixel(i, MapHeight - 1, BorderColor).Draw();
        }
        for (int i = 0; i < MapHeight; i++) //vertical border
        {
            new Pixel(0, i, BorderColor).Draw();
            new Pixel(MapWidth - 1, i, BorderColor).Draw();
        }
    }

}