using static System.Console;

namespace Snake_v1;
class Program
{
    static void Main()
    {
        SetWindowSize(StartGameClass.ScreenWidth, StartGameClass.ScreenHeight);
        //SetWindowSize(ScreenWidth, ScreenHeight);
        SetBufferSize(StartGameClass.ScreenWidth, StartGameClass.ScreenHeight);
        //SetBufferSize(ScreenWidth, ScreenHeight);
        CursorVisible = false;
        while (true)
        {
            StartGameClass.StartGame();
            ReadKey();
        }
    }
}