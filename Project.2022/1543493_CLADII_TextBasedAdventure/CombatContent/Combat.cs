using CLADII_TextBasedAdventure.EntityContent;
using CLADII_TextBasedAdventure.EntityContent.EntityTypes;
using CLADII_TextBasedAdventure.ItemContent;
using CLADII_TextBasedAdventure.UserInterfaceContent;
using System;
using System.Collections.Generic;
using System.Text;

namespace CLADII_TextBasedAdventure.CombatContent
{
    public class Combat
    {
        public static void CombatScenario(List<HumanEntity> npcs)
        {
            CyberTechBanners.AresCombatBanner();

            while (!HumanEntity.player.isDead || npcs.Count > 0)
            {
                HumanEntity chosen = TargetEnemy(npcs);
                Weapon weaponUsed = ChooseWeapon();
                Skill weaponSkill = Weapon.GetWeaponSkill(weaponUsed);
                Utils.LbL($"\n{chosen} targeted.", ConsoleColor.Red);
                BodyPartData targetPart = TargetBodyPart(weaponSkill, chosen);
                Utils.LbL($"\n{targetPart.name} locked in.", ConsoleColor.Red);
                PlayerAttemptAttack(weaponSkill, weaponUsed, chosen, targetPart);
            }
        }

        private static Weapon ChooseWeapon()
        {
            Utils.LbL($"\n## Equipped Weapons ##", ConsoleColor.Cyan);
            for (int i = 0; i < HumanEntity.player.equippedWeapons.Count; i++)
            {
                Console.WriteLine($"\n{i + 1}. {HumanEntity.player.equippedWeapons[i]}");
            }

            Console.Write("\nWeapon selected (#): ");
            int.TryParse(Console.ReadLine(), out int inputNum);

            while (true)
            {
                if (inputNum > 0 && inputNum <= HumanEntity.player.equippedWeapons.Count)
                {
                    return HumanEntity.player.equippedWeapons[inputNum - 1];
                }
                else
                {
                    Console.WriteLine("\nInput a valid number.");
                    return ChooseWeapon();
                }
            }
        }

        private static HumanEntity TargetEnemy(List<HumanEntity> npcs)
        {
            Utils.LbL("\nAcquiring targets", ConsoleColor.Red, newLine: false);
            Utils.LbL("...", ConsoleColor.Red, 350);

            for (int i = 0; i < npcs.Count; i++)
            {
                Utils.LbL($"\n{i + 1}. {npcs[i]}", ConsoleColor.Yellow);
            }

            Console.WriteLine("\nWho do you want to target?");
            int.TryParse(Console.ReadLine(), out int inputNum);

            while (true)
            {
                if (inputNum > 0 && inputNum <= npcs.Count)
                {
                    return npcs[inputNum - 1];
                }
                else
                {
                    Console.WriteLine("\nInput a valid number.");
                    return TargetEnemy(npcs);
                }
            }
        }

        private static BodyPartData TargetBodyPart(Skill weaponSkill, HumanEntity npc)
        {
            int index = 1;
            foreach (BodyPartData part in npc.bodyParts)
            {
                Console.WriteLine($"\n{index}. {part.name}\nHit Chance: {part.baseHitChance + weaponSkill.level}%");
                index++;
            }
            Console.WriteLine("\nChoose the body part you want to target.");
            int.TryParse(Console.ReadLine(), out int inputNum);

            if (inputNum > 0 && inputNum <= index)
            {
                return npc.bodyParts[inputNum - 1];
            }
            else
            {
                Console.WriteLine("\nInput a valid number.");
                return TargetBodyPart(weaponSkill, npc);
            }
        }

        private static void PlayerAttemptAttack(Skill skill, Weapon item, HumanEntity npc, BodyPartData bodyPart)
        {
            int attemptAttack = new Random().Next(0, 101);
            Console.WriteLine($"\nAttack roll: {attemptAttack}");
            if (attemptAttack <= bodyPart.baseHitChance + skill.level)
            {
                bodyPart.health -= item.damage;
                if (bodyPart.health <= 0)
                {
                    bodyPart.health = 0;
                    Console.WriteLine(bodyPart.health);
                }
                switch (item.typeSkill)
                {
                    case Weapon.SkillType.BladeMeleeCombat:
                        {
                            Utils.LbL($"\n{npc.name}'s {bodyPart.name.ToLower()} slashed with {item.name}.", ConsoleColor.Red);
                        }
                        break;
                    case Weapon.SkillType.BluntMeleeCombat:
                        {
                            Utils.LbL($"\n{npc.name}'s {bodyPart.name.ToLower()} bludgeoned with {item.name}.", ConsoleColor.Red);
                        }
                        break;
                    case Weapon.SkillType.UnarmedMeleeCombat:
                        {
                            Utils.LbL($"\n{npc.name}'s {bodyPart.name.ToLower()} struck with {item.name}.", ConsoleColor.Red);
                        }
                        break;
                    case Weapon.SkillType.OneHandFirearms:
                        {
                            Utils.LbL($"\n{npc.name}'s {bodyPart.name.ToLower()} hit with {item.name}.", ConsoleColor.Red);
                        }
                        break;
                    case Weapon.SkillType.TwoHandFirearms:
                        {
                            Utils.LbL($"\n{npc.name}'s {bodyPart.name.ToLower()} hit with {item.name}.", ConsoleColor.Red);
                        }
                        break;
                }
            }
            else
            {
                Console.WriteLine("\nAttack missed.");
            }
        }

        private static void EnemyAttemptAttack(HumanEntity npc, Skill skill, Weapon item, HumanEntity player, BodyPartData bodyPart)
        {
            int attemptAttack = new Random().Next(0, 101);
            Console.WriteLine($"\nAttack roll: {attemptAttack}");
            if (attemptAttack <= bodyPart.baseHitChance + skill.level)
            {
                bodyPart.health -= item.damage;

                switch (item.typeSkill)
                {
                    case Weapon.SkillType.BladeMeleeCombat:
                        {
                            Utils.LbL($"\n{npc.name}'s {bodyPart.name} slashed with {item.name}.", ConsoleColor.Green);
                        }
                        break;
                    case Weapon.SkillType.BluntMeleeCombat:
                        {
                            Utils.LbL($"\n{npc.name}'s {bodyPart.name} bludgeoned with {item.name}.", ConsoleColor.Green);
                        }
                        break;
                    case Weapon.SkillType.UnarmedMeleeCombat:
                        {
                            Utils.LbL($"\n{npc.name}'s {bodyPart.name} struck with {item.name}.", ConsoleColor.Green);
                        }
                        break;
                    case Weapon.SkillType.OneHandFirearms:
                        {
                            Utils.LbL($"\n{npc.name}'s {bodyPart.name} hit with {item.name}.", ConsoleColor.Green);
                        }
                        break;
                    case Weapon.SkillType.TwoHandFirearms:
                        {
                            Utils.LbL($"\n{npc.name}'s {bodyPart.name} hit with {item.name}.", ConsoleColor.Green);
                        }
                        break;
                }
            }
            else
            {
                Utils.LbL("\nAttack missed.", ConsoleColor.DarkGray);
            }
        }
    }
}
