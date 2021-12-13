using CLADII_TextBasedAdventure.CombatContent;
using CLADII_TextBasedAdventure.ItemContent;
using System;
using System.Collections.Generic;
using System.Text;

namespace CLADII_TextBasedAdventure.EntityContent.EntityTypes
{
    public class HumanEntity : EntityData
    {
        public static HumanEntity player = new HumanEntity("The Protagonist");

        public int age;
        public List<Skill> skills = new List<Skill>();
        public CortexCoreItem cortexCurrent = CortexCoreItem.cortechI;
        public BodyType bodyType;
        public List<Weapon> equippedWeapons = new List<Weapon>();
        public List<Weapon> virtualArsenal = new List<Weapon>();
        public List<Item> backpack = new List<Item>();
        public bool crippledArm = false;
        public bool crippledLeg = false;
        public bool isDead = false;
        public bool newGame = true;
        public bool intro1 = true;
        public bool intro2 = true;
        public bool intro3 = true;
        public bool intro4 = true;
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

        public MeleeWeapon strikeFists = new MeleeWeapon("Strike (Fists)")
        {
            damage = 4,
            type = Weapon.WeaponType.HandToHand,
            typeSkill = Weapon.SkillType.UnarmedMeleeCombat
        };

        public MeleeWeapon strikeKicks = new MeleeWeapon("Strike (Kicks)")
        {
            damage = 6,
            type = Weapon.WeaponType.HandToHand,
            typeSkill = Weapon.SkillType.UnarmedMeleeCombat
        };

        public HumanEntity(string name) : base(name)
        {
            skills = Skill.CreateSkills();
            InitBaseWeapons();
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

        protected void InitBaseWeapons()
        {
            equippedWeapons.Add(strikeFists);
            equippedWeapons.Add(strikeKicks);
        }

        public static void ResetPlayerCharacter()
        {
            player.age = 18;
            player.skills.Clear();
            player.skills = Skill.CreateSkills();
            player.cortexCurrent = CortexCoreItem.cortechI;
            player.bodyType = BodyType.Neutral;
            player.equippedWeapons.Clear();
            player.equippedWeapons = new List<Weapon>();
            player.virtualArsenal.Clear();
            player.virtualArsenal = new List<Weapon>();
            player.backpack.Clear();
            player.backpack = new List<Item>();
            player.crippledArm = false;
            player.crippledLeg = false;
            player.isDead = false;
            player.newGame = true;
            player.intro1 = true;
            player.intro2 = true;
            player.intro3 = true;
            player.intro4 = true;
            player.playtime = 0;
        }
    }
}
