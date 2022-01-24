using CLADII_TextBasedAdventure.EntityContent;
using CLADII_TextBasedAdventure.EntityContent.EntityTypes;
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
            UnarmedCombatSkill unarmedCombatSkill = new UnarmedCombatSkill();
            BluntWeaponCombatSkill bluntWeaponCombatSkill = new BluntWeaponCombatSkill();
            BladeWeaponCombatSkill bladeWeaponCombatSkill = new BladeWeaponCombatSkill();
            OneHandFirearmsSkill oneHandFirearmsSkill = new OneHandFirearmsSkill();
            TwoHandFirearmsSkill twoHandFirearmsSkill = new TwoHandFirearmsSkill();
            EngineeringSkill engineeringSkill = new EngineeringSkill();
            SpeechSkill speechSkill = new SpeechSkill();
            NarcoticsSkill narcoticsSkill = new NarcoticsSkill();

            skills.Add(unarmedCombatSkill);
            skills.Add(bluntWeaponCombatSkill);
            skills.Add(bladeWeaponCombatSkill);
            skills.Add(oneHandFirearmsSkill);
            skills.Add(twoHandFirearmsSkill);
            skills.Add(engineeringSkill);
            skills.Add(speechSkill);
            skills.Add(narcoticsSkill);

            return skills;
        }

        /// <summary>
        /// Return the list of player skills.
        /// </summary>
        public static int PrintPCSkills()
        {
            int listNum = 1;
            foreach (Skill skill in HumanEntity.player.skills)
            {
                Utils.LbL($"\n{listNum++}. {skill.name}\nLevel: {skill.level}", ConsoleColor.DarkMagenta, 1, speedCustom: true);
            }
            return listNum;
        }
    }

    public class UnarmedCombatSkill : Skill
    {
        public UnarmedCombatSkill() : base("Unarmed Combat", 0) { }
    }

    public class BladeWeaponCombatSkill : Skill
    {
        public BladeWeaponCombatSkill() : base("Blade Weapon Combat", 0) { }
    }

    public class BluntWeaponCombatSkill : Skill
    {
        public BluntWeaponCombatSkill() : base("Blunt Weapon Combat", 0) { }
    }

    public class OneHandFirearmsSkill : Skill
    {
        public OneHandFirearmsSkill() : base("One-Hand Firearms", 0) { }
    }

    public class TwoHandFirearmsSkill : Skill
    {
        public TwoHandFirearmsSkill() : base("Two-Hand Firearms", 0) { }
    }

    public class EngineeringSkill : Skill
    {
        public EngineeringSkill() : base("Engineering", 0) { }
    }

    public class SpeechSkill : Skill
    {
        public SpeechSkill() : base ("Speech", 0) { }
    }

    public class NarcoticsSkill : Skill
    {
        public NarcoticsSkill() : base ("Narcotics", 0) { }
    }
}