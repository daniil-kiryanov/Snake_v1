using System.Diagnostics;
public class StartGameClass
{
    public const int ScreenWidth = DrawBorderClass.MapWidth * 3;
    public const int ScreenHeight = DrawBorderClass.MapHeight * 3;
    private const ConsoleColor HeadColor = ConsoleColor.Red;
    private const ConsoleColor BodyColor = ConsoleColor.Green;

    private const int FrameMs = 200;//перерыв между кадрами

    public static void StartGame()
    {
        //DrawBorderClass drawBorderClass = new DrawBorderClass();
        //GenFoodClass genFoodClass = new GenFoodClass();
        Console.Clear();//чистим консоль
        DrawBorderClass.DrawBorder();
        //DrawBorder();//рисуем борты
        Direction currentMovement = Direction.Right;//задаем начальное движение вправо
        var snake = new Snake(10, 5, HeadColor, BodyColor);//set location snake with color
        Pixel food = GenFoodClass.GenFood(snake);//за
        food.Draw();
        int score = 0;
        Stopwatch sw = new Stopwatch();//класс секундомер
        while (true)
        {
            sw.Restart();
            Direction oldMovement = currentMovement;//текущее движение в олд
            while (sw.ElapsedMilliseconds <= FrameMs)//пока идет 200 мс
            {
                if (currentMovement == oldMovement)//проверка на изменение направления движения
                {
                    currentMovement = ReadMovementClass.ReadMovement(currentMovement);
                }
            }

            if (snake.Head.X == food.X && snake.Head.Y == food.Y)//если голова и еда встретились 
            {
                snake.Move(currentMovement, true);//продолжаем движение и eat = true

                food = GenFoodClass.GenFood(snake);//рисуем новую еду
                food.Draw();

                score++;//увеличиваем счетчик результата
            }
            else
            {
                snake.Move(currentMovement);
            }

            if (snake.Head.X == DrawBorderClass.MapWidth - 1
                || snake.Head.X == 0
                || snake.Head.Y == DrawBorderClass.MapHeight - 1
                || snake.Head.Y == 0
                || snake.Body.Any(b => b.X == snake.Head.X && b.Y == snake.Head.Y))
                break;
        }
        snake.Clear();
        Console.SetCursorPosition(ScreenWidth / 4, ScreenHeight / 2);
        Console.WriteLine($"Game Over! Your score: {score}. \nPress ENTER to start a new game...");
    }
}