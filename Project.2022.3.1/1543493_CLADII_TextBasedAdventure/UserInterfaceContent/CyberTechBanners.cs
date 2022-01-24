using System;
using System.Collections.Generic;
using System.Text;

namespace CLADII_TextBasedAdventure.UserInterfaceContent
{
    public static class CyberTechBanners
    {
        /// <summary>
        /// Print Ares banner for when combat starts, and for intro.
        /// </summary>
        public static void AresCombatBanner()
        {
            Utils.LbL(@"   _   ___ ___ ___    ___ ___  __  __ ___   _ _____   __  __  ___  ___  _   _ _    ___ 
  /_\ | _ \ __/ __|  / __/ _ \|  \/  | _ ) /_\_   _| |  \/  |/ _ \|   \| | | | |  | __|
 / _ \|   / _|\__ \ | (_| (_) | |\/| | _ \/ _ \| |   | |\/| | (_) | |) | |_| | |__| _| 
/_/ \_\_|_\___|___/  \___\___/|_|  |_|___/_/ \_\_|   |_|  |_|\___/|___/ \___/|____|___|", ConsoleColor.Red, speed: 0, speedCustom: true);
        }

        /// <summary>
        /// Print NewMe banner when the player wants to change their character,
        /// and for intro.
        /// </summary>
        public static void NewMeBanner()
        {
            Utils.LbL(@"
█▄░█ █▀▀ █░█░█ █▀▄▀█ █▀▀ ░ █▀▀ ▀▄▀ █▀▀
█░▀█ ██▄ ▀▄▀▄▀ █░▀░█ ██▄ ▄ ██▄ █░█ ██▄", ConsoleColor.Magenta, speed: 1, speedCustom: true);
        }

        /// <summary>
        /// Print Glancer banner when player wants to examine another character.
        /// </summary>
        public static void GlancerBanner()
        {
            Utils.LbL(@"
█████▀███████████████████████████████████████
█─▄▄▄▄█▄─▄████▀▄─██▄─▀█▄─▄█─▄▄▄─█▄─▄▄─█▄─▄▄▀█
█─██▄─██─██▀██─▀─███─█▄▀─██─███▀██─▄█▀██─▄─▄█
▀▄▄▄▄▄▀▄▄▄▄▄▀▄▄▀▄▄▀▄▄▄▀▀▄▄▀▄▄▄▄▄▀▄▄▄▄▄▀▄▄▀▄▄▀", ConsoleColor.Cyan, 1, speedCustom: true);
        }
    }
}
