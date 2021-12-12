using CLADII_TextBasedAdventure.BackEndContent;
using CLADII_TextBasedAdventure.EntityContent;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CLADII_TextBasedAdventure.SaveSystem
{
    class SaveData
    {
        /// <summary>
        /// If the main save directory Saves doesn't exist,
        /// create it.
        /// </summary>
        public static void Directories()
        {
            if (!Directory.Exists($"Saves"))
            {
                Directory.CreateDirectory($"Saves");
            }
        }

        /// <summary>
        /// If a directory doesn't exist within Saves that has
        /// the character's name, create one. Set the player's
        /// play time and then serialize the player to .json.
        /// Save the file name as the total time played in DateTime.
        /// </summary>
        public static void Save()
        {
            if (!Directory.Exists($"Saves\\{HumanEntity.player.name}"))
            {
                Directory.CreateDirectory($"Saves\\{HumanEntity.player.name}");
            }
            
            HumanEntity.player.playtime = Playtime.GetTotalPlayTime();
            DateTime gameTime = Playtime.GetSessionLengthAsDateTime();

            string save = JsonConvert.SerializeObject(HumanEntity.player);

            File.WriteAllText($"Saves\\{HumanEntity.player.name}\\{gameTime.ToString("H.mm.ss.ff")}.json", save);
        }

        /// <summary>
        /// Check to see if any character directories exist inside the main
        /// Saves directory.
        /// </summary>
        /// <returns>Return true if there is a directory available to access.</returns>
        public static bool GetSaves()
        {
            Directories();
            var direc = Directory.GetDirectories("Saves");
            if (direc.Length == 0)
            {
                Console.WriteLine("\nThere are no saves available.");
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Make a list of character directories inside main Saves directory.
        /// Have player choose character from list and access the character directory.
        /// List all saves in that character's directory and let player choose
        /// a save from there. Which save they choose, return the static player to
        /// be the player from that file.
        /// </summary>
        /// <returns></returns>
        public static HumanEntity Load()
        {
            bool getSaves = GetSaves();
            if (!getSaves)
            {
                return null;
            }
            else
            {
                Console.WriteLine("\nChoose a character to load:\n");

                int dirListNum = 1;
                var dirMainArray = Directory.GetDirectories("Saves");

                foreach (string folder in dirMainArray)
                {
                    Console.WriteLine($"{dirListNum++}. {Path.GetFileName(folder)}");
                }
                Console.WriteLine($"{dirListNum}. Go back");

                string input = Utils.GetInput();
                
                if (!int.TryParse(input, out int inputNum) || inputNum < 0 || inputNum > dirMainArray.Length + 1)
                {
                    Console.WriteLine("\nInput a valid number.");
                    return null;
                }
                else if (inputNum == dirListNum)
                {
                    return null;
                }

                string dirCharName = Path.GetFileName(Directory.GetDirectories("Saves")[inputNum - 1]);
                var dirCharArray = Directory.GetDirectories("Saves")[inputNum - 1];

                Console.WriteLine($"\nChoose a save from character: {dirCharName}");

                int fileListNum = 1;
                foreach (string file in Directory.GetFiles(dirCharArray))
                {
                    Console.WriteLine($"{fileListNum++}. {Path.GetFileName(file)}");
                }
                Console.WriteLine($"{fileListNum}. Go back");

                input = Utils.GetInput();

                if (!int.TryParse(input, out inputNum) || inputNum < 0 && inputNum > dirCharArray.Length + 1)
                {
                    Console.WriteLine("\nInput a valid number.");
                    return null;
                }
                else if (inputNum == fileListNum)
                {
                    return null;
                }

                string saveName = Path.GetFileName(Directory.GetFiles(dirCharArray)[inputNum - 1]);

                return JsonConvert.DeserializeObject<HumanEntity>(File.ReadAllText($"Saves\\{dirCharName}\\{saveName}"));
            }
        }
    }
}
