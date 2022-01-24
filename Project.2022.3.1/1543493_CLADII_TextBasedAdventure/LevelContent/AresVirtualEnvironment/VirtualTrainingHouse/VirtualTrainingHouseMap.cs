using System;
using System.Collections.Generic;
using System.Text;

namespace CLADII_TextBasedAdventure.LevelContent.AresVirtualEnvironment.VirtualTrainingHouse
{
    public class VirtualTrainingHouseMap : Map
    {
        public static VirtualTrainingHouseRoom1Map virtualTrainingHouseRoom1;
        public VirtualTrainingHouseMap() : base("Virtual Training House", Location.AresVirtualTrainingHouse)
        {
            virtualTrainingHouseRoom1 = new VirtualTrainingHouseRoom1Map();
        }
    }
}
