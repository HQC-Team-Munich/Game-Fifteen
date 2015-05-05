namespace GameFifteen
{
    using Core;

    public class GameFifteenMain
    {
        public static void Main()
        {
            Engine gameFifteenEngine = Engine.Instance;

            gameFifteenEngine.Run();
        }
    }
}