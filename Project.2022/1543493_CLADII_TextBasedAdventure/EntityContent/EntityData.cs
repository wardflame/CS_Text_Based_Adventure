using CLADII_TextBasedAdventure.BackEndContent;
using CLADII_TextBasedAdventure.CombatContent;
using CLADII_TextBasedAdventure.ItemContent;
using CLADII_TextBasedAdventure.LevelContent;
using CLADII_TextBasedAdventure.ProfessionContent;
using System;
using System.Collections.Generic;
using System.Text;

namespace CLADII_TextBasedAdventure.EntityContent
{
    public class EntityData
    {
        public string name;
        public List<BodyPartData> bodyParts = new List<BodyPartData>();
        public Map currentLocation;

        public EntityData(string name)
        {
            this.name = name;
            InitBodyParts();
        }

        protected virtual void InitBodyParts()
        {
        }

        public virtual void EntityStatus()
        {
        }

        public static void ReplenishBodyParts(List<EntityData> entities)
        {
            foreach (EntityData entity in entities)
            {
                foreach (BodyPartData bodyPart in entity.bodyParts)
                {
                    //bodyPart.health;
                }
            }
        }
    }
}
