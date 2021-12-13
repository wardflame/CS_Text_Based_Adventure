using CLADII_TextBasedAdventure.CombatContent;
using CLADII_TextBasedAdventure.EntityContent.EntityTypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace CLADII_TextBasedAdventure.ItemContent
{
    public class Item
    {
        public string name;
        public string description;
        public int quantity;

        public Item(string name)
        {
            this.name = name;
        }

        public override string ToString()
        {
            return $"{name}";
        }
    }

    public class Weapon : Item
    {
        public int damage;
        public int condition;
        public WeaponType type;
        public SkillType typeSkill;

        public enum WeaponType
        {
            HandToHand,
            Hammer,
            Knife,
            Sword,
            Pistol,
            Rifle,
            Shotgun,
        }

        public enum SkillType
        {
            UnarmedMeleeCombat,
            BluntMeleeCombat,
            BladeMeleeCombat,
            OneHandFirearms,
            TwoHandFirearms
        }

        public Weapon(string name) : base(name)
        {

        }
        public static Skill GetWeaponSkill(Weapon chosenWeapon)
        {
            switch (chosenWeapon.typeSkill)
            {
                case Weapon.SkillType.UnarmedMeleeCombat:
                    {
                        return HumanEntity.player.skills.Find(skill => skill.name == "Unarmed Combat");
                    }
                case Weapon.SkillType.BladeMeleeCombat:
                    {
                        return HumanEntity.player.skills.Find(skill => skill.name == "Blade Weapon Combat");
                    }
                case Weapon.SkillType.BluntMeleeCombat:
                    {
                        return HumanEntity.player.skills.Find(skill => skill.name == "Blunt Weapon Combat");
                    }
                case Weapon.SkillType.OneHandFirearms:
                    {
                        return HumanEntity.player.skills.Find(skill => skill.name == "One-Hand Firearms");
                    }
                case Weapon.SkillType.TwoHandFirearms:
                    {
                        return HumanEntity.player.skills.Find(skill => skill.name == "Two-Hand Firearms");
                    }
                default:
                    {
                        Console.WriteLine("\nUnable to find a skill.");
                        return null;
                    }
            }
        }
    }

    public class MeleeWeapon : Weapon
    {
        public MeleeWeapon(string name) : base(name)
        {
        }
    }

    public class FirearmWeapon : Weapon
    {
        public FirearmWeapon(string name) : base(name)
        {
        }
    }

    public class CortexCoreItem : Item
    {
        public static CortexCoreItem cortechI = new CortexCoreItem("Cortech-I Cortex Implant", 3.000f);

        public float skillMemory;
        public CortexCoreItem(string name, float skillMemory) : base(name)
        {
            this.name = name;
            this.skillMemory = skillMemory;
        }
    }
}
