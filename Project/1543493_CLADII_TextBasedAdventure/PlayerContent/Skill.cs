using _1543493_CLADII_TextBasedAdventure.EntityContent;
using System;
using System.Collections.Generic;
using System.Text;

namespace _1543493_CLADII_TextBasedAdventure.PlayerContent
{
    public class Skill
    {
        public string name;
        public int valueBase;

        public Skill(string name, int valueBase)
        {
            this.name = name;
            this.valueBase = valueBase;
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
            return $"{name}\n{valueBase}";
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