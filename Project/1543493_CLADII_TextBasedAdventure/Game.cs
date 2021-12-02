using _1543493_CLADII_TextBasedAdventure.CombatContent;
using _1543493_CLADII_TextBasedAdventure.EntityContent;
using _1543493_CLADII_TextBasedAdventure.ItemContent;
using _1543493_CLADII_TextBasedAdventure.NPCContent;
using _1543493_CLADII_TextBasedAdventure.PlayerContent;
using System;
using System.Collections.Generic;
using System.Text;

namespace _1543493_CLADII_TextBasedAdventure
{
    public class Game
    {
        //Player player = Player.CharacterCreator();

        public void Running()
        {
            bool testing = true;
            
            while(testing)
            {
                HumanEntity player = new HumanEntity("Protagonist", Skill.CreateSkills())
                {
                    age = 24,
                    bodyType = HumanEntity.BodyType.Masculine
                };
                player.InitBodyParts();

                Skill oneHand = player.skills.Find(skill => skill.name == "One-Hand Firearms");
                oneHand.level = 45;
                FirearmWeapon pistol = new FirearmWeapon("CLAD-II", 45, 100, FirearmWeapon.WeaponType.Pistol, Item.SkillType.OneHandFirearms);
                player.equipped.Add(pistol);

                NPC enemy = new NPC("Antagonist", 24, NPC.Gender.Male);
                enemy.entity.InitBodyParts();

                List<NPC> enemies = new List<NPC>();
                enemies.Add(enemy);

                Combat.CombatScenario(player, enemies);
            }

            
        }
    }
}
