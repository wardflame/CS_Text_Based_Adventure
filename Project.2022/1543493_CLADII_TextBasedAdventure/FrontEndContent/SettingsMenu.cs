using CLADII_TextBasedAdventure.BackEndContent;
using CLADII_TextBasedAdventure.EntityContent;
using CLADII_TextBasedAdventure.SaveSystem;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace CLADII_TextBasedAdventure.FrontEndContent
{
    public class SettingsMenu
    {
        /// <summary>
        /// Settings menu designed for various tweakable features.
        /// In this 'demo' of the game, one parameter is available:
        /// Text speed. This is for speeding up or slowing down the
        /// letter-by-letter method that prints the narrative text.
        /// </summary>
        public static void InSettings()
        {
            bool inSettings = true;
            while (inSettings)
            {
                Console.Clear();
                Utils.LbL(@"
▒█▀▀▀█ ▒█▀▀▀ ▀▀█▀▀ ▀▀█▀▀ ▀█▀ ▒█▄░▒█ ▒█▀▀█ ▒█▀▀▀█ 
░▀▀▀▄▄ ▒█▀▀▀ ░▒█░░ ░▒█░░ ▒█░ ▒█▒█▒█ ▒█░▄▄ ░▀▀▀▄▄ 
▒█▄▄▄█ ▒█▄▄▄ ░▒█░░ ░▒█░░ ▄█▄ ▒█░░▀█ ▒█▄▄█ ▒█▄▄▄█
", ConsoleColor.Magenta, speedCustom: true);
                Utils.LbL("1. Type Speed\n2. Return to Main Menu", speedCustom: true);

                string input = Utils.GetInput();
                switch (input)
                {
                    case "1":
                        {
                            Console.Write($"\nChoose a speed (in milliseconds) at which game text is printed character-by-character.\nDefault: 50\nCurrent: {GameSettings.gameSettings.textSpeed}\nNew speed (input # between 0-1000): ");
                            bool checkingInput = true;
                            while (checkingInput)
                            {
                                input = Utils.GetInput();
                                if (!int.TryParse(input, out int inputNum) || inputNum < 0 || inputNum > 70)
                                {
                                    Console.WriteLine("\nInput a valid number.");
                                }
                                else
                                {
                                    GameSettings.gameSettings.textSpeed = inputNum;
                                    Utils.LbL($"\nText speed set to: {GameSettings.gameSettings.textSpeed}");
                                    SaveData.SaveGameSettings();
                                    Thread.Sleep(1000);
                                    checkingInput = false;
                                }
                            }
                        }
                        break;
                    case "2":
                        {
                            Console.Clear();
                            inSettings = false;
                        }
                        break;
                    default:
                        {
                            Console.WriteLine("\nInput a valid number.");
                            Thread.Sleep(1000);
                            Console.Clear();
                        }
                        break;
                }
            }
        }
    }
}
