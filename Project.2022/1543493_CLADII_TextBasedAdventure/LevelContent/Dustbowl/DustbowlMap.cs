using System;
using System.Collections.Generic;
using System.Text;

namespace CLADII_TextBasedAdventure.LevelContent.Dustbowl
{
    public class DustbowlMap : Map
    {
        public BusStationMap busStationMap = new BusStationMap();
        public DustbowlMap() : base("Dustbowl", Location.Dustbowl)
        {
            AddMap(new BusStationMap());
        }
    }
}
