﻿using System.Diagnostics;
using static System.Console;


namespace Snake_v1
{
    public class StartGameClass
    {
        public const int MapWidth = 30;
        public const int MapHeight = 20;
        public const int ScreenWidth = MapWidth * 3;
        public const int ScreenHeight = MapHeight * 3;

        private const ConsoleColor BorderColor = ConsoleColor.Gray;
        private const ConsoleColor HeadColor = ConsoleColor.Red;
        private const ConsoleColor BodyColor = ConsoleColor.Green;
        private const ConsoleColor FoodColor = ConsoleColor.Blue;

        private const int FrameMs = 200;
        private static readonly Random random = new Random();

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
        public static Pixel GenFood(Snake snake)
        {
            Pixel food;
            do
            {
                food = new Pixel(random.Next(1, MapWidth - 2), random.Next(1, MapHeight - 2), FoodColor);
            } while (snake.Head.X == food.X && snake.Head.Y == food.Y
                    || snake.Body.Any(b => b.X == food.X && b.Y == food.Y));
            return food;
        }
    }
}
