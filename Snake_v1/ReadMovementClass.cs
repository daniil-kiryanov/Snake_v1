using static System.Console;

namespace Snake_v1
{
    public class ReadMovementClass
    {

        public static Direction ReadMovement(Direction currentDirection)
        {
            if (!KeyAvailable) //true if a key press is available; otherwise, false
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