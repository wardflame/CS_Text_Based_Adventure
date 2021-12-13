using CLADII_TextBasedAdventure.CombatContent;
using CLADII_TextBasedAdventure.EntityContent;
using CLADII_TextBasedAdventure.ItemContent;
using CLADII_TextBasedAdventure.LevelContent;
using CLADII_TextBasedAdventure.SaveSystem;
using System;
using System.Collections.Generic;
using System.Text;

namespace CLADII_TextBasedAdventure
{
    public class Game
    {
        //Player player = Player.CharacterCreator();

        public void Running()
        {
            bool testing = true;
            HumanEntity player = new HumanEntity("Protagonist")
            {
                age = 24,
                bodyType = HumanEntity.BodyType.Masc,
                currentLocation = new WorldMap().dustbowlMap
            };

            while (testing)
            {

                Skill oneHand = player.skills.Find(skill => skill.name == "One-Hand Firearms");
                oneHand.level = 45;
                FirearmWeapon pistol = new FirearmWeapon("CLAD-II", 45, 100, FirearmWeapon.WeaponType.Pistol, Item.SkillType.OneHandFirearms);
                player.equipped.Add(pistol);

                HumanEntity enemy = new HumanEntity("Antagonist");

                List<HumanEntity> enemies = new List<HumanEntity>();
                enemies.Add(enemy);

                Movement.Traversal(player);

                if (player.currentLocation.location == Location.BusStation)
                {
                    Combat.CombatScenario(player, enemies);
                }
            }
        }
    }
}
