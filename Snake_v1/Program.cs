using static System.Console;

namespace Snake_v1;
class Program : StartGameClass
{
    static void Main()
    {
        SetWindowSize(ScreenWidth, ScreenHeight);
        SetBufferSize(ScreenWidth, ScreenHeight);
        CursorVisible = false;

        while (true)
        {
            StartGame();
            ReadKey();
        }
    }
}