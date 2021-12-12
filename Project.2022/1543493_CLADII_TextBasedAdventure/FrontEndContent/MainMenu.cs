using CLADII_TextBasedAdventure.BackEndContent;
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
        /// <summary>
        /// Main menu for the game. Provides access to a new game,
        /// the ability to resume a game by loading a character,
        /// access settings to tweak features, or to exit the application.
        /// </summary>
        /// <returns>Returns false to exit menu game loop in Game.</returns>
        public static bool InMainMenu()
        {
            // Game title ascii.
            Utils.LbL(@"──────────────────────────────────────────────────────────────────────────────────────────────────
─██████████████─██████─────────██████████████─████████████──────────────────██████████─██████████─
─██░░░░░░░░░░██─██░░██─────────██░░░░░░░░░░██─██░░░░░░░░████────────────────██░░░░░░██─██░░░░░░██─
─██░░██████████─██░░██─────────██░░██████░░██─██░░████░░░░██────────────────████░░████─████░░████─
─██░░██─────────██░░██─────────██░░██──██░░██─██░░██──██░░██──────────────────██░░██─────██░░██───
─██░░██─────────██░░██─────────██░░██████░░██─██░░██──██░░██─██████████████───██░░██─────██░░██───
─██░░██─────────██░░██─────────██░░░░░░░░░░██─██░░██──██░░██─██░░░░░░░░░░██───██░░██─────██░░██───
─██░░██─────────██░░██─────────██░░██████░░██─██░░██──██░░██─██████████████───██░░██─────██░░██───
─██░░██─────────██░░██─────────██░░██──██░░██─██░░██──██░░██──────────────────██░░██─────██░░██───
─██░░██████████─██░░██████████─██░░██──██░░██─██░░████░░░░██────────────────████░░████─████░░████─
─██░░░░░░░░░░██─██░░░░░░░░░░██─██░░██──██░░██─██░░░░░░░░████────────────────██░░░░░░██─██░░░░░░██─
─██████████████─██████████████─██████──██████─████████████──────────────────██████████─██████████─
──────────────────────────────────────────────────────────────────────────────────────────────────
", ConsoleColor.DarkRed, speedCustom: true);

            Console.WriteLine("1. New Game\n2. Load Game\n3. Settings\n4. Exit Game");

            // Swithc for navigating menu methods.
            string input = Utils.GetInput();
            switch (input)
            {
                case "1":
                    {
                        Playtime.StartPlaytime();
                        PlayerCreator.CreateCharacter();
                        SaveData.Save();
                        return false;
                    }
                case "2":
                    {
                        HumanEntity.player = SaveData.Load();
                        if (HumanEntity.player == null)
                        {
                            Thread.Sleep(1000);
                            Console.Clear();
                            return true;
                        }
                        Playtime.StartPlaytime();
                        return false;
                    }
                case "3":
                    {
                        SettingsMenu.InSettings();
                        return true;
                    }
                case "4":
                    {
                        Environment.Exit(0);
                        Playtime.ResetPlaytime();
                        return false;
                    }
                default:
                    {
                        Utils.LbL("Input a valid number.", speedCustom: true);
                        Thread.Sleep(1000);
                        Console.Clear();
                        return true;
                    }
            }
        }
    }
}
