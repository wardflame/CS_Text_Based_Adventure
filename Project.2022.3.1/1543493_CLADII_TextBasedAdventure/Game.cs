using CLADII_TextBasedAdventure.BackEndContent;
using CLADII_TextBasedAdventure.EntityContent.EntityTypes;
using CLADII_TextBasedAdventure.FrontEndContent;
using CLADII_TextBasedAdventure.LevelContent;
using CLADII_TextBasedAdventure.SaveSystem;
using System;
using System.Collections.Generic;
using System.Text;

namespace CLADII_TextBasedAdventure
{
    public class Game
    {

        public void Running()
        {
            GameSettings.gameSettings = SaveData.LoadGameSettings();

            bool isMainMenu = true;
            while (isMainMenu)
            {
                isMainMenu = MainMenu.InMainMenu();
            }

            bool playing = true;
            while (playing)
            {
                // Run intro sequence if new game.
                if (HumanEntity.player.newGame)
                {
                    if (HumanEntity.player.intro1)
                    {
                        HumanEntity.player.currentLocation = Map.worldMap.introBusMap;
                        HumanEntity.player.currentLocation.OnEnterFirst();
                        HumanEntity.player.intro1 = false;
                        SaveData.SavePlayerCharacter();                        
                    }
                    if (HumanEntity.player.intro2)
                    {
                        HumanEntity.player.currentLocation = Map.worldMap.introBusMap.virtualCombatMap;
                        HumanEntity.player.currentLocation.OnEnterFirst();
                        HumanEntity.player.intro2 = false;
                        SaveData.SavePlayerCharacter();
                    }
                    if (HumanEntity.player.intro3)
                    {
                        HumanEntity.player.currentLocation = Map.worldMap.introBusMap.virtualCombatMap.virtualShootingRangeMap;
                        HumanEntity.player.currentLocation.OnEnterFirst();
                        HumanEntity.player.intro3 = false;
                        SaveData.SavePlayerCharacter();
                    }
                    if (HumanEntity.player.intro4)
                    {
                        HumanEntity.player.currentLocation = Map.worldMap.dustbowlMap.busStationMap;
                        HumanEntity.player.currentLocation.OnEnterFirst();
                        HumanEntity.player.intro4 = false;
                        SaveData.SavePlayerCharacter();
                    }
                    HumanEntity.player.newGame = false;
                }

                Utils.LbL("\nThank you for playing the CLAD-II demo. Would you like to start again? (y/n)", ConsoleColor.Green);
                while (true)
                {
                    switch (Utils.GetInput())
                    {
                        case "y":
                            {
                                Utils.ConsoleUp();
                                return;
                            }
                        case "n":
                            {
                                Environment.Exit(0);
                            }
                            break;
                        default:
                            {
                                Console.WriteLine("\nInput y/n.");
                            }
                            break;
                    }
                }
            }
        }
    }
}
