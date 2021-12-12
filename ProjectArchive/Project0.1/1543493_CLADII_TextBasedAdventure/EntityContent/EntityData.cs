using _1543493_CLADII_TextBasedAdventure.ItemContent;
using _1543493_CLADII_TextBasedAdventure.PlayerContent;
using _1543493_CLADII_TextBasedAdventure.ProfessionContent;
using System;
using System.Collections.Generic;
using System.Text;

namespace _1543493_CLADII_TextBasedAdventure.EntityContent
{
    public class EntityData
    {
        public string name;
        public List<Skill> skills = new List<Skill>();
        public List<BodyPartData> bodyParts = new List<BodyPartData>();
        public List<Item> equipped = new List<Item>();
        public List<Item> backpack = new List<Item>();

        public EntityData(string name, List<Skill> skills)
        {
            this.name = name;
            this.skills = skills;
        }

        public virtual void InitBodyParts()
        {
        }
    }

    public class HumanEntity : EntityData
    {
        public int age;
        public Profession profession;
        public BodyType bodyType;

        public enum BodyType
        {
            Masculine,
            Feminine,
            Neutral
        }

        public BodyPartData head = new BodyPartData("Head", 10, 5);
        public BodyPartData torso = new BodyPartData("Torso", 50, 40);
        public BodyPartData armL = new BodyPartData("Left Arm", 30, 25);
        public BodyPartData armR = new BodyPartData("Right Arm", 30, 25);
        public BodyPartData legL = new BodyPartData("Left Leg", 25, 30);
        public BodyPartData legR = new BodyPartData("Right Leg", 25, 30);

        public HumanEntity(string name, List<Skill> skills) : base(name, skills)
        {
            this.name = name;
            this.skills = skills;
        }

        /// <summary>
        /// Necessary? Should be...
        /// </summary>
        public override void InitBodyParts()
        {
            bodyParts.Add(head);
            bodyParts.Add(torso);
            bodyParts.Add(armL);
            bodyParts.Add(armR);
            bodyParts.Add(legL);
            bodyParts.Add(legR);
        }
    }
}
