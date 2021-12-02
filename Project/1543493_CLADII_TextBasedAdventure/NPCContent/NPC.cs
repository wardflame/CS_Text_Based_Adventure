using _1543493_CLADII_TextBasedAdventure.EntityContent;
using _1543493_CLADII_TextBasedAdventure.PlayerContent;
using _1543493_CLADII_TextBasedAdventure.ProfessionContent;
using System;
using System.Collections.Generic;
using System.Text;

namespace _1543493_CLADII_TextBasedAdventure.NPCContent
{
    public class NPC
    {
        public string name;
        public int age;
        public Gender gender;
        public List<Skill> playerSkills;
        public Profession profession;
        public HumanEntity entity = new HumanEntity();

        public enum Gender
        {
            Male,
            Female,
            Other
        }

        public NPC(string name, int age, Gender gender) : base()
        {
            this.name = name;
            this.age = age;
            this.gender = gender;
        }

        public override string ToString()
        {
            return $">> {name}";
        }
    }
}
