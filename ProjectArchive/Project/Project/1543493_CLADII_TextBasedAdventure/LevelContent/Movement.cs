using CLADII_TextBasedAdventure.EntityContent;
using System;
using System.Collections.Generic;
using System.Text;

namespace CLADII_TextBasedAdventure.LevelContent
{
    public class Movement
    {
        public static void Traversal(HumanEntity player)
        {
            Map map = player.currentLocation;
            for (int i = 0; i < map.innerMaps.Count; i++)
            {
                Utils.LbL($"{i + 1}. {map.innerMaps[i].name}");
            }
            if (player.currentLocation.parentMap != null)
            {
                Utils.LbL($"{map.innerMaps.Count + 1}. Go back.");
            }
            Utils.LbL("Where do you want to go? #");

            int.TryParse(Utils.GetInput(), out int mapIndex);
            mapIndex--;
            if (mapIndex >= map.innerMaps.Count && map.parentMap != null)
            {
                player.currentLocation = map.parentMap;
            }
            else
            {
                player.currentLocation = map.innerMaps[mapIndex];
            }
        }
    }
}
