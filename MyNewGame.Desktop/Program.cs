using osu.Framework.Platform;
using osu.Framework;
using MyNewGame.Game;

namespace MyNewGame.Desktop
{
    public static class Program
    {
        public static void Main()
        {
            using (GameHost host = Host.GetSuitableDesktopHost(@"MyNewGame"))
            using (osu.Framework.Game game = new MyNewGameGame())
                host.Run(game);
        }
    }
}
