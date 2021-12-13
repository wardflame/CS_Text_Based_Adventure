using CLADII_TextBasedAdventure.EntityContent;
using System;
using System.Collections.Generic;
using System.Text;

namespace CLADII_TextBasedAdventure.CombatContent
{
    public class Skill
    {
        public string name;
        public int level;
        public int progression;

        public Skill(string name, int valueBase)
        {
            this.name = name;
            this.level = valueBase;
        }

        public static List<Skill> CreateSkills()
        {
            List<Skill> skills = new List<Skill>();
            MeleeCombatSkill meleeCombatSkill = new MeleeCombatSkill();
            OneHandFirearmsSkill oneHandFirearmsSkill = new OneHandFirearmsSkill();
            TwoHandFirearmsSkill twoHandFirearmsSkill = new TwoHandFirearmsSkill();

            skills.Add(meleeCombatSkill);
            skills.Add(oneHandFirearmsSkill);
            skills.Add(twoHandFirearmsSkill);

            return skills;
        }

        public override string ToString()
        {
            return $"{name}\n{level}";
        }
    }

    public class MeleeCombatSkill : Skill
    {
        public MeleeCombatSkill() : base("Melee Combat", 0) { }
    }

    public class OneHandFirearmsSkill : Skill
    {
        public OneHandFirearmsSkill() : base("One-Hand Firearms", 0) { }
    }

    public class TwoHandFirearmsSkill : Skill
    {
        public TwoHandFirearmsSkill() : base("Two-Hand Firearms", 0) { }
    }
}