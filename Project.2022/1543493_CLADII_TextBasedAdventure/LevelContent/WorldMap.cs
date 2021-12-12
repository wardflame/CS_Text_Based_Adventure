using CLADII_TextBasedAdventure.LevelContent.Dustbowl;
using System;
using System.Collections.Generic;
using System.Text;

namespace CLADII_TextBasedAdventure.LevelContent
{
    public class WorldMap : Map
    {
        public DustbowlMap dustbowlMap;

        public WorldMap() : base("World", Location.World)
        {
            dustbowlMap = AddMap(new DustbowlMap());
        }
    }
}
