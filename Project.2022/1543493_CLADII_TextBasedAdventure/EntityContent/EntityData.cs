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
    }

    public class HumanEntity : EntityData
    {
        public static HumanEntity player = new HumanEntity("The Protagonist");

        public int age;
        public Profession profession;
        public List<Skill> skills = new List<Skill>();
        public BodyType bodyType;
        public List<Item> equipped = new List<Item>();
        public List<Item> backpack = new List<Item>();
        public long playtime = 0;

        public enum BodyType
        {
            Masc,
            Fem,
            Neutral
        }

        public BodyPartData head = new BodyPartData("Head", 10, 5);
        public BodyPartData torso = new BodyPartData("Torso", 50, 30);
        public BodyPartData armL = new BodyPartData("Left Arm", 30, 15);
        public BodyPartData armR = new BodyPartData("Right Arm", 30, 15);
        public BodyPartData legL = new BodyPartData("Left Leg", 25, 20);
        public BodyPartData legR = new BodyPartData("Right Leg", 25, 20);

        public HumanEntity(string name) : base(name)
        {
            this.skills = Skill.CreateSkills();
        }

        /// <summary>
        /// Necessary? Should be...
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

        public override string ToString()
        {
            return name;
        }
    }
}
