using CLADII_TextBasedAdventure.SaveSystem;
using System;

namespace CLADII_TextBasedAdventure
{
    class Program
    {
        public static bool running = true;
        static void Main(string[] args)
        {
            while (running)
            {
                Game game = new Game();
                game.Running();
            }
        }

    }
}
