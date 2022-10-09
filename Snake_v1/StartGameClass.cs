using System.Diagnostics;

namespace Snake_v1
{
    public class StartGameClass //: DrawBorderClass
    {
        public const int ScreenWidth = DrawBorderClass.MapWidth * 3;
        public const int ScreenHeight = DrawBorderClass.MapHeight * 3;
        private const ConsoleColor HeadColor = ConsoleColor.Red;
        private const ConsoleColor BodyColor = ConsoleColor.Green;

        private const int FrameMs = 200;

        public static void StartGame()
        {
            DrawBorderClass drawBorderClass = new DrawBorderClass();
            //GenFoodClass genFoodClass = new GenFoodClass();
            Console.Clear();//чистим консоль
            drawBorderClass.DrawBorder();
            //DrawBorder();//рисуем борты
            Direction currentMovement = Direction.Right;//задаем начальное движение
            var snake = new Snake(10, 5, HeadColor, BodyColor);//set location snake with color
            Pixel food = GenFoodClass.GenFood(snake);
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
                        currentMovement = ReadMovementClass.ReadMovement(currentMovement);
                    }
                }

                if (snake.Head.X == food.X && snake.Head.Y == food.Y)
                {
                    snake.Move(currentMovement, true);

                    food = GenFoodClass.GenFood(snake);
                    food.Draw();

                    score++;
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
}
