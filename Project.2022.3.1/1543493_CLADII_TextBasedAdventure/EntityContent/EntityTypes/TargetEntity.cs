using System;
using System.Collections.Generic;
using System.Text;

namespace CLADII_TextBasedAdventure.EntityContent.EntityTypes
{
    public class TargetEntity : EntityData
    {
        public bool isDead = false;

        public BodyPartData head = new BodyPartData("Head", 5, 20);
        public BodyPartData torso = new BodyPartData("Torso", 20, 60);
        public BodyPartData armL = new BodyPartData("Left Arm", 10, 30);
        public BodyPartData armR = new BodyPartData("Right Arm", 10, 30);
        public BodyPartData legL = new BodyPartData("Left Leg", 15, 40);
        public BodyPartData legR = new BodyPartData("Right Leg", 15, 40);

        public TargetEntity(string name) : base(name)
        {
        }

        /// <summary>
        /// Add bodyparts to list.
        /// </summary>
        protected override void InitBodyParts()
        {
            bodyParts.Add(head);
            bodyParts.Add(torso);
            bodyParts.Add(armL);
            bodyParts.Add(armR);
            bodyParts.Add(legL);
            bodyParts.Add(legR);
        }

        /// <summary>
        /// If the head or torso body parts are 'killed,' kill the entity.
        /// </summary>
        public override void EntityStatus()
        {
            float statusHead = bodyParts.Find(x => x.name == head.name).health;
            float statusTorso = bodyParts.Find(x => x.name == torso.name).health;
            if (statusHead <= 0 || 0 >= statusTorso)
            {
                isDead = true;
            }
        }

        public override string ToString()
        {
            return name;
        }
    }
}
