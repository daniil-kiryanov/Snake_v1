namespace Snake_v1
{
    public class DrawBorderClass : GenFoodClass
    {
        public const int MapWidth = 25;
        public const int MapHeight = 25;

        private const ConsoleColor BorderColor = ConsoleColor.Gray;

        public static void DrawBorder()
        {
            
            for (int i = 0; i < MapWidth; i++) //horizontal border
            {
                new Pixel(i, 0, BorderColor).Draw();//верхний борт
                new Pixel(i, MapHeight - 1, BorderColor).Draw();//нижний борт
            }
            for (int i = 0; i < MapHeight; i++) //vertical border
            {
                new Pixel(0, i, BorderColor).Draw();//left border
                new Pixel(MapWidth - 1, i, BorderColor).Draw();//right border
            }
        }
    }
}