using CLADII_TextBasedAdventure.EntityContent;
using CLADII_TextBasedAdventure.PlayerContent;
using CLADII_TextBasedAdventure.SaveSystem;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace CLADII_TextBasedAdventure.FrontEndContent
{
    public static class MainMenu
    {
        public static bool StartMenu()
        {
            Utils.LbL(@"   _____ _               _____       _____ _____ 
  / ____| |        /\   |  __ \     |_   _|_   _|
 | |    | |       /  \  | |  | |______| |   | |  
 | |    | |      / /\ \ | |  | |______| |   | |  
 | |____| |____ / ____ \| |__| |     _| |_ _| |_ 
  \_____|______/_/    \_\_____/     |_____|_____|
", ConsoleColor.Red, 0);

            Utils.LbL(@"1. New Game
2. Load Game
3. Exit Game", speed: 0);

            string input = Utils.GetInput();
            if (!int.TryParse(input, out int inputNum) || inputNum < 1 || inputNum > 3)
            {
                Utils.LbL("\nInput a valid number.");
                Thread.Sleep(1000);
                Console.Clear();
                return StartMenu();
            }

            switch (inputNum)
            {
                case 1:
                    {
                        HumanEntity.player = PlayerCreator.CreatePlayer();
                        return false;
                    }
                case 2:
                    {
                        HumanEntity.player = SaveData.Load();
                    }
                    break;
            }
        }
    }
}
