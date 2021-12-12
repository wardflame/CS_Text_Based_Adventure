using CLADII_TextBasedAdventure.PlayerContent;
using System;
using System.Collections.Generic;
using System.Text;

namespace CLADII_TextBasedAdventure.LevelContent.Dustbowl
{
    public class BusStation : Map
    {
        public static bool gameStart = true;

        public BusStation() : base("Bus Station", Location.BusStation)
        {
        }

        public override void OnEnter()
        {
            if (gameStart)
            {
                OnEnterFirst();
            }
        }

        public override void OnEnterFirst()
        {
            PlayerCreator.CreateCharacter();
        }
    }
}
