using System;
using System.Collections.Generic;
using System.Text;

namespace _1543493_CLADII_TextBasedAdventure.EntityContent
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
    }
}
