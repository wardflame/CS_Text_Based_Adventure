using System;
using System.Collections.Generic;
using System.Text;

namespace CLADII_TextBasedAdventure.LevelContent
{
    public class Map
    {
        public string name;
        public Map parentMap;
        public List<Map> innerMaps = new List<Map>();
        public Location location;

        public Map(string name, Location location)
        {
            this.name = name;
            this.location = location;
        }

        protected T AddMap<T>(T map) where T : Map
        {
            map.parentMap = this;
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
    }

    public enum Location
    {
        World,
        Dustbowl,
        BusStation
    }
}
