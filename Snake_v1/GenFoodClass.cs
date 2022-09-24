namespace Snake_v1
{
    public class GenFoodClass
    {
        private const ConsoleColor FoodColor = ConsoleColor.Blue;
        private static readonly Random random = new Random();

        public static Pixel GenFood(Snake snake)
        {
            Pixel food;
            do
            {
                food = new Pixel(random.Next(1, DrawBorderClass.MapWidth - 2), random.Next(1, DrawBorderClass.MapHeight - 2), FoodColor);
            } while (snake.Head.X == food.X && snake.Head.Y == food.Y
                    || snake.Body.Any(b => b.X == food.X && b.Y == food.Y));
            return food;
        }
    }
}