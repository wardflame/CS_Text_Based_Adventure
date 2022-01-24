using System;
using System.Collections.Generic;
using System.Text;

namespace CLADII_TextBasedAdventure.LevelContent
{
    public class Map
    {
        public string name;
        public Location parentMapLocation;
        public List<Map> innerMaps = new List<Map>();
        public Location location;

        public static WorldMap worldMap = new WorldMap();

        public Map(string name, Location location)
        {
            this.name = name;
            this.location = location;
        }

        protected T AddMap<T>(T map) where T : Map
        {
            map.parentMapLocation = location;
            innerMaps.Add(map);
            return map;
        }

        public virtual void OnEnter()
        {
        }

        public virtual void OnEnterFirst()
        {
        }

        public virtual void OnExit()
        {
        }

        /// <summary>
        /// Search for map to return by enum. If this isn't the map,
        /// search through this map's inner maps to see if it's there.
        /// </summary>
        /// <param name="location"></param>
        /// <returns>Map to use.</returns>
        public Map GetInnerMapByLocation(Location location)
        {
            if (this.location == location)
            {
                return this;
            }
            foreach (Map innerMap in innerMaps)
            {
                Map map = innerMap.GetInnerMapByLocation(location);
                if (map != null)
                {
                    return innerMap;
                }
            }
            return null;
        }
    }

    public enum Location
    {
        None,
        World,
        IntroBus,
        AresVirtualCombatEnvironment,
        AresVirtualShootingRange,
        AresVirtualTrainingHouse,
        AresVirtualTrainingHouseRoom1,
        Dustbowl,
        BusStation
    }
}
