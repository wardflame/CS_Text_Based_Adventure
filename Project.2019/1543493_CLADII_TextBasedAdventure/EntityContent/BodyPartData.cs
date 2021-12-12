using System;
using System.Collections.Generic;
using System.Text;

namespace CLADII_TextBasedAdventure.EntityContent
{
    public class BodyPartData
    {
        public string name;
        public float health;
        public int baseHitChance;

        public BodyPartData(string name, float health, int baseHitChance)
        {
            this.name = name;
            this.health = health;
            this.baseHitChance = baseHitChance;
        }

        public override string ToString()
        {
            return $">> {name}\nHit Chance: {baseHitChance}%";
        }
    }
}
