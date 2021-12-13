using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace CLADII_TextBasedAdventure
{
    public static class Utils
    {
        public static string GetInput(bool toLower = false, bool trim = false)
        {
            string str = Console.ReadLine();

            if (toLower)
            {
                str = str.ToLower();
            }
            
            if (trim)
            {
               str = str.Trim();
            }
            
            return str;
        }

        /// <summary>
        /// Letter-by-letter LbL print of a string.
        /// </summary>
        /// <param name="input">String to be output.</param>
        /// <param name="color">Color of the text.</param>
        /// <param name="speed">How fast it should print.</param>
        /// <param name="newLine">If there should be a new line after.</param>
        public static void LbL(string input, ConsoleColor color = ConsoleColor.Gray, int speed = 1, bool newLine = true)
        {
            Console.ForegroundColor = color;
            foreach (char c in input)
            {
                Thread.Sleep(speed);
                Console.Write(c);
            }
            Console.ResetColor();
            if (newLine)
            {
                Console.WriteLine();
            }
        }

        /// <summary>
        /// String with color (SwC). Parse in a string and process with colour.
        /// Provide boolean to see if the string should be a Write() (true) or
        /// a WriteLine() (false).
        /// </summary>
        /// <param name="input">String to be processed with colour.</param>
        /// <param name="color">Desired colour for string.</param>
        /// <param name="writeOrLine">Whether the string should be a Write(true) or WriteLine(false).</param>
        public static void SwC(string input, ConsoleColor color, bool writeOrLine)
        {
            Console.ForegroundColor = color;
            if (writeOrLine)
            {
                Console.Write(input);
            }
            else
            {
                Console.WriteLine(input);
            }
            Console.ResetColor();
        }

        /// <summary>
        /// Generic method to ask whether a situation was correct or incorrect. Parse in
        /// the question to be repeated in the event of an invalid response.
        /// </summary>
        /// <param name="userInput"></param>
        /// <returns></returns>
        public static bool InputVerification(string userInput)
        {
            while (true)
            {
                Console.WriteLine(userInput);

                string inputReply = Console.ReadLine().ToLower().Trim();

                switch (inputReply)
                {
                    case "yes":
                    case "y":
                        {
                            return true;
                        }
                    case "no":
                    case "n":
                        {
                            return false;
                        }
                }
            }
        }

        /// <summary>
        /// Pushes previous text off screen without clearing the console.
        /// Used for simulating a console.clear without removing information
        /// from the player.
        /// </summary>
        public static void ConsoleUp()
        {
            for (int i = 0; i < Console.WindowHeight; i++)
            {
                Console.WriteLine();
            } 
        }

        public static void MenuScreen()
        {
            Console.WriteLine();
        }
    }
}
