using CLADII_TextBasedAdventure.LevelContent.Dustbowl;
using CLADII_TextBasedAdventure.LevelContent.IntroBus;
using System;
using System.Collections.Generic;
using System.Text;

namespace CLADII_TextBasedAdventure.LevelContent
{
    public class WorldMap : Map
    {
        public IntroBusMap introBusMap = new IntroBusMap();
        public DustbowlMap dustbowlMap = new DustbowlMap();

        public WorldMap() : base("World", Location.World)
        {
            dustbowlMap = AddMap(new DustbowlMap());
            introBusMap = AddMap(new IntroBusMap());
        }
    }
}
