using static System.Console;
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