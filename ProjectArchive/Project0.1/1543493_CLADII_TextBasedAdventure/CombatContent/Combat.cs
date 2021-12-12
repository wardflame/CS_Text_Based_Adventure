using _1543493_CLADII_TextBasedAdventure.EntityContent;
using _1543493_CLADII_TextBasedAdventure.ItemContent;
using _1543493_CLADII_TextBasedAdventure.NPCContent;
using _1543493_CLADII_TextBasedAdventure.PlayerContent;
using System;
using System.Collections.Generic;
using System.Text;

namespace _1543493_CLADII_TextBasedAdventure.CombatContent
{
    public class Combat
    {
        public static void CombatScenario(EntityData player, List<NPC> npcs)
        {
            Utilities.LbL(@"
▄▀█ █▀█ █▀▀ █▀   █▀▀ █▀█ █▀▄▀█ █▄▄ ▄▀█ ▀█▀   █▀▄▀█ █▀█ █▀▄ █░█ █░░ █▀▀
█▀█ █▀▄ ██▄ ▄█   █▄▄ █▄█ █░▀░█ █▄█ █▀█ ░█░   █░▀░█ █▄█ █▄▀ █▄█ █▄▄ ██▄", ConsoleColor.Red, 1, true);

            Item weaponUsed = ChooseWeapon(player.equipped);
            Skill weaponSkill = GetPlayerWeaponSkill(player, weaponUsed);
            NPC chosen = TargetEnemy(npcs);
            Utilities.LbL($"\n{chosen} targeted.", ConsoleColor.Red, 40, true);
            BodyPartData targetPart = TargetBodyPart(weaponSkill, chosen);
            Utilities.LbL($"\n{targetPart.name} locked in.", ConsoleColor.Red, 40, true);
            PlayerAttemptAttack(weaponSkill, weaponUsed, chosen, targetPart);

            Console.ReadKey();
        }

        private static Item ChooseWeapon(List<Item> equipped)
        {
            Utilities.LbL($"\n## Equipped Weapons ##", ConsoleColor.Cyan, 20, true);
            for (int i = 0; i < equipped.Count; i++)
            {
                Console.WriteLine($"\n{i + 1}. {equipped[i]}");
            }

            Console.Write("\nWeapon selected (#): ");
            int.TryParse(Console.ReadLine(), out int inputNum);

            while (true)
            {
                if (inputNum > 0 && inputNum <= equipped.Count)
                {
                    return equipped[inputNum - 1];
                }
                else
                {
                    Console.WriteLine("\nInput a valid number.");
                    return ChooseWeapon(equipped);
                }
            }
        }

        private static Skill GetPlayerWeaponSkill(EntityData player, Item item)
        {
            switch (item.type)
            {
                case Item.WeaponType.Pistol:
                    {
                        return player.skills.Find(skill => skill.name == "One-Hand Firearms");
                    }
                default:
                    {
                        Console.WriteLine("\nNot in this test.");
                        return GetPlayerWeaponSkill(player, item);
                    }
            }
        }

        private static NPC TargetEnemy(List<NPC> npcs)
        {
            Utilities.LbL("\nAcquiring targets", ConsoleColor.Red, 60, false);
            Utilities.LbL("...", ConsoleColor.Red, 350, true);

            for (int i = 0; i < npcs.Count; i++)
            {
                Utilities.LbL($"\n{i + 1}. {npcs[i]}", ConsoleColor.Yellow, 20, true);
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

        private static BodyPartData TargetBodyPart(Skill weaponSkill, NPC npc)
        {
            int index = 1;
            foreach (BodyPartData part in npc.entity.bodyParts)
            {
                Console.WriteLine($"\n{index}. {part.name}\nHit Chance: {part.baseHitChance + weaponSkill.level}%");
                index++;
            }
            Console.WriteLine("\nChoose the body part you want to target.");
            int.TryParse(Console.ReadLine(), out int inputNum);

            if (inputNum > 0 && inputNum <= index)
            {
                return npc.entity.bodyParts[inputNum - 1];
            }
            else
            {
                Console.WriteLine("\nInput a valid number.");
                return TargetBodyPart(weaponSkill, npc);
            }
        }

        private static void PlayerAttemptAttack(Skill skill, Item item, NPC npc, BodyPartData bodyPart)
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
                    case Item.SkillType.BladeMeleeCombat:
                        {
                            Utilities.LbL($"\n{npc.name}'s {bodyPart.name.ToLower()} slashed with {item.name}.", ConsoleColor.Red, 20, true);
                        }
                        break;
                    case Item.SkillType.BluntMeleeCombat:
                        {
                            Utilities.LbL($"\n{npc.name}'s {bodyPart.name.ToLower()} bludgeoned with {item.name}.", ConsoleColor.Red, 20, true);
                        }
                        break;
                    case Item.SkillType.UnarmedCombat:
                        {
                            Utilities.LbL($"\n{npc.name}'s {bodyPart.name.ToLower()} struck with {item.name}.", ConsoleColor.Red, 20, true);
                        }
                        break;
                    case Item.SkillType.OneHandFirearms:
                        {
                            Utilities.LbL($"\n{npc.name}'s {bodyPart.name.ToLower()} hit with {item.name}.", ConsoleColor.Red, 20, true);
                        }
                        break;
                    case Item.SkillType.TwoHandFirearms:
                        {
                            Utilities.LbL($"\n{npc.name}'s {bodyPart.name.ToLower()} hit with {item.name}.", ConsoleColor.Red, 20, true);
                        }
                        break;
                }
            }
            else
            {
                Console.WriteLine("\nAttack missed.");
            }
        }

        private static void EnemyAttemptAttack(NPC npc, Skill skill, Item item, EntityData player, BodyPartData bodyPart)
        {
            int attemptAttack = new Random().Next(0, 101);
            Console.WriteLine($"\nAttack roll: {attemptAttack}");
            if (attemptAttack <= bodyPart.baseHitChance + skill.level)
            {
                bodyPart.health -= item.damage;

                switch (item.typeSkill)
                {
                    case Item.SkillType.BladeMeleeCombat:
                        {
                            Utilities.LbL($"\n{npc.name}'s {bodyPart.name} slashed with {item.name}.", ConsoleColor.Green, 20, true);
                        }
                        break;
                    case Item.SkillType.BluntMeleeCombat:
                        {
                            Utilities.LbL($"\n{npc.name}'s {bodyPart.name} bludgeoned with {item.name}.", ConsoleColor.Green, 20, true);
                        }
                        break;
                    case Item.SkillType.UnarmedCombat:
                        {
                            Utilities.LbL($"\n{npc.name}'s {bodyPart.name} struck with {item.name}.", ConsoleColor.Green, 20, true);
                        }
                        break;
                    case Item.SkillType.OneHandFirearms:
                        {
                            Utilities.LbL($"\n{npc.name}'s {bodyPart.name} hit with {item.name}.", ConsoleColor.Green, 20, true);
                        }
                        break;
                    case Item.SkillType.TwoHandFirearms:
                        {
                            Utilities.LbL($"\n{npc.name}'s {bodyPart.name} hit with {item.name}.", ConsoleColor.Green, 20, true);
                        }
                        break;
                }
            }
            else
            {
                Utilities.LbL("\nAttack missed.", ConsoleColor.DarkGray, 20, true);
            }
        }
    }
}
