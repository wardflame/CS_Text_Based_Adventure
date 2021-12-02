using System;

namespace _1543493_CLADII_TextBasedAdventure
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
