using static System.Console;
public class ReadMovementClass
{

    public static Direction ReadMovement(Direction currentDirection)
    {
        if (!KeyAvailable)
            return currentDirection;//если ничего не нажато возвращаем предыдущее направление
        ConsoleKey key = ReadKey(true).Key;//считываем кнопку
        currentDirection = key switch// 
        {
            ConsoleKey.UpArrow when currentDirection != Direction.Down => Direction.Up,//если нажали вверх, если движение не вниз, то возвращаем вверх
            ConsoleKey.DownArrow when currentDirection != Direction.Up => Direction.Down,
            ConsoleKey.LeftArrow when currentDirection != Direction.Right => Direction.Left,
            ConsoleKey.RightArrow when currentDirection != Direction.Left => Direction.Right,
            _ => currentDirection // знак _ вместо default
        };
        return currentDirection;
    }
}