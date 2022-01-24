using CLADII_TextBasedAdventure.EntityContent.EntityTypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace CLADII_TextBasedAdventure.LevelContent
{
    public class Movement
    {
        public static void Traversal(bool noBack = false)
        {
            Map map = HumanEntity.player.currentLocation;
            for (int i = 0; i < map.innerMaps.Count; i++)
            {
                Utils.LbL($"{i + 1}. {map.innerMaps[i].name}");
            }
            if (HumanEntity.player.currentLocation.parentMapLocation != Location.None && noBack == false)
            {
                Utils.LbL($"{map.innerMaps.Count + 1}. Go back.");
            }
            Utils.LbL("Where do you want to go? #");

            int.TryParse(Utils.GetInput(), out int mapIndex);
            mapIndex--;
            if (mapIndex >= map.innerMaps.Count && map.parentMapLocation != Location.None)
            {
                HumanEntity.player.currentLocation = Map.worldMap.GetInnerMapByLocation(map.parentMapLocation);
            }
            else
            {
                HumanEntity.player.currentLocation = map.innerMaps[mapIndex];
            }
        }
    }
}
