using System;
using System.Collections.Generic;
using System.Text;

namespace CLADII_TextBasedAdventure.LevelContent.Dustbowl
{
    public class DustbowlMap : Map
    {
        public DustbowlMap() : base("Dustbowl", Location.Dustbowl)
        {
            AddMap(new BusStation());
        }
    }
}
