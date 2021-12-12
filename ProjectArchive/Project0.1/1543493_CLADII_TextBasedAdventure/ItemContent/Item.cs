using _1543493_CLADII_TextBasedAdventure.PlayerContent;
using System;
using System.Collections.Generic;
using System.Text;

namespace _1543493_CLADII_TextBasedAdventure.ItemContent
{
    public class Item
    {
        public string name;
        public int damage;
        public int durability;
        public WeaponType type;
        public SkillType typeSkill;
 
        public enum WeaponType
        {
            Fist,
            Hammer,
            Knife,
            Sword,
            Pistol,
            Rifle,
            Shotgun,
        }

        public enum SkillType
        {
            UnarmedCombat,
            BluntMeleeCombat,
            BladeMeleeCombat,
            OneHandFirearms,
            TwoHandFirearms
        }

        public override string ToString()
        {
            return $"{name}\nDamage: {damage}\nDurability: {durability}%";
        }
    }

    public class MeleeWeapon : Item
    {
        
    }

    public class FirearmWeapon : Item
    {
        public FirearmWeapon(string name, int damage, int durability, WeaponType type, SkillType typeSkill)
        {
            this.name = name;
            this.damage = damage;
            this.durability = durability;
            this.type = type;
            this.typeSkill = typeSkill;
        }
    }
}
