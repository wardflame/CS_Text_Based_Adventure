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
    }

    public class MeleeWeapon : Item
    {
        

        public enum Type
        {
            Fist,
            Hammer,
            Knife,
            Sword
        }
    }

    public class FirearmWeapon : Item
    {
        public FirearmWeapon(string name, int damage, int durability, Type typeFirearm)
        {
            this.name = name;
            this.damage = damage;
            this.durability = durability;
        }

        public enum Type
        {
            Pistol,
            Rifle,
            Shotgun,
        }
    }
}
