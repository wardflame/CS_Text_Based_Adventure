using CLADII_TextBasedAdventure.EntityContent;
using CLADII_TextBasedAdventure.EntityContent.EntityTypes;
using CLADII_TextBasedAdventure.ItemContent;
using System;
using System.Collections.Generic;
using System.Text;

namespace CLADII_TextBasedAdventure.LevelContent.AresVirtualEnvironment.VirtualShootingRange
{
    public class VirtualShootingRangeMap : Map
    {
        public static bool firstTimeRange = true;

        public List<Weapon> shootingRangeArsenal = new List<Weapon>();
        public List<TargetEntity> targets = new List<TargetEntity>();

        public VirtualShootingRangeMap() : base("Virtual Shooting Range", Location.AresVirtualShootingRange)
        {
        }

        /// <summary>
        /// Player arrives in the shooting range. Introduced to the concept of combat and
        /// target acquisition.
        /// </summary>
        public override void OnEnterFirst()
        {
            Utils.LbL(@"    It takes a good half-minute to recover from the run, which aggravates Jones
to no end, but you head under the gazebo and stand at a booth on the range. Jones
crosses the range to a rack on wheels and pulls it over to you. There's an assortment 
of pistols, rifles and shotguns, all barrel-up on the rack.
");
            Utils.LbL(@"    [JONES]", ConsoleColor.Red);
            Utils.LbL(@"    'See these here weapons, private? They're your new sweetheart. These fine pieces
of deathbringing are what brought this nation up to what it is today, and, now, you're
gonna learn how to master 'em. I formally congratulate you on your success in basic
combat training, but now you're onto the fun stuff. As part of the Ares Combat Programme,
it's my honour to host you through your weapons training.

    No more chatter. Let's get to it. Choose a weapon from the rack.'");
            Utils.LbL(@"    [/JONES]", ConsoleColor.Red);


            Utils.LbL(@"
    As Jones stops speaking, there's a blinker in your vision. Widgets appear around
the various guns on the rack, displaying key information about the weapons.
");
            InitRangeInventory();
            InitRangeTargets();
            Weapon chosenWeapon = ChooseRangeWeapon();
            string wName = chosenWeapon.name;
            // Dialogue switch in accordance with the chosen weapon.
            switch (wName)
            {
                case "CLAD-I":
                    {
                        Utils.LbL($@"   [JONES]", ConsoleColor.Red);
                        Utils.LbL($@"   '{wName}, the old faithful, made in 2102. One of the first energy weapons, no less.
A fine bit of kit, if a little out-dated. Let's get you throwing some of that power down range.'");
                        Utils.LbL($@"   [/JONES]", ConsoleColor.Red);
                    }
                    break;
                case "CLAD-II":
                    {
                        Utils.LbL($@"   [JONES]", ConsoleColor.Red);
                        Utils.LbL($@"   '{wName}, son of the CLAD-I and chief defence weapon amongst all walks of life, that weapon
doesn't care who you are or what you do. Built on the power of its predecessor but with refined recoil
and overall stability and conditioning, it's had to go wrong with the {wName}.'");
                        Utils.LbL($@"   [/JONES]", ConsoleColor.Red);
                    }
                    break;
                case "Bucky Shotgun":
                    {
                        Utils.LbL($@"   [JONES]", ConsoleColor.Red);
                        Utils.LbL($@"   'Shotguns were the staple of home defence and close-quarters combat for a long time, and the {wName}
was at the forefront of that age. It'll turn a person to paste within ten metres. Not the best
weapon going for ranged confrontations, but it'll give the enemy enough to think about behind cover.'");
                        Utils.LbL($@"   [/JONES]", ConsoleColor.Red);
                    }
                    break;
                case "R-AR":
                    {
                        Utils.LbL($@"   [JONES]", ConsoleColor.Red);
                        Utils.LbL($@"   '{wName}, the Rapid-Assault Rifle, was developed in 2117, two decades ago. Since its invention,
close-quarters combat has been dominated by it. Capable of barrel transitions mid-combat,
easy operation and peerless reliability, any soldiers or armed officers would give an arm and leg
to have one on their person.'");
                        Utils.LbL($@"   [/JONES]", ConsoleColor.Red);
                    }
                    break;
            }

            Utils.LbL(@"
    Jones presses a button at your side, deploying a target some fifteen metres away.
");
            Utils.LbL($@"   [JONES]", ConsoleColor.Red);
            Utils.LbL($@"   'All right, private, you're hitting fifteens in this session--wanna see how you shoot. You'll
see the targets poppin' up in your HUD, Heads Up Display, in just a moment. Choose one, concentrate
on it, and the Ares Combat Module will display the enemy's body parts. Focus on one of those and the
Module will do the rest. Choose a target now:'");
            Utils.LbL($@"   [/JONES]", ConsoleColor.Red);

            TargetEntity target = ChooseTarget();

            Utils.LbL($@"   [JONES]", ConsoleColor.Red);
            Utils.LbL($@"   'Good work. Now, select a body part. Fire on the target until it's down.'");
            Utils.LbL($@"   [/JONES]", ConsoleColor.Red);

            // Keep player shooting at target until it is 'dead,' then continue.
            bool shootingTarget = true;
            while (shootingTarget)
            {
                BodyPartData bodyPart = ChooseBodyPart(chosenWeapon, target);
                AttemptShot(chosenWeapon, target, bodyPart);
                target.EntityStatus();
                if (target.isDead)
                {
                    Utils.LbL($"\n{target.name} down. Removing from the range...");
                    targets.Remove(target);
                    shootingTarget = false;
                }
            }

            Console.WriteLine();
            Utils.LbL($@"   [JONES]", ConsoleColor.Red);
            Utils.LbL($@"   'Congratulations, private. You've just slain your first target. How's it feel?'");
            Utils.LbL($@"   [/JONES]", ConsoleColor.Red);
            Console.WriteLine();

            Utils.LbL(@"    Just as Jones can mock you some more, his face grows dark and intense.");

            Console.WriteLine();
            Utils.LbL($@"   [JONES]", ConsoleColor.Red);
            Utils.LbL($@"   'You've gotta go...'");
            Utils.LbL($@"   [/JONES]", ConsoleColor.Red);
            Console.WriteLine();
        }

        /// <summary>
        /// Clear any previous targets on the range and replace them with
        /// new, fresh entities.
        /// </summary>
        public void InitRangeTargets()
        {
            targets.Clear();

            TargetEntity target1 = new TargetEntity("Target 1");
            TargetEntity target2 = new TargetEntity("Target 2");
            TargetEntity target3 = new TargetEntity("Target 3");
            TargetEntity target4 = new TargetEntity("Target 4");

            targets.Add(target1);
            targets.Add(target2);
            targets.Add(target3);
            targets.Add(target4);
        }

        /// <summary>
        /// Clear any previous virtual range/player inventory and replenish stock with new
        /// weapons.
        /// </summary>
        public void InitRangeInventory()
        {
            shootingRangeArsenal.Clear();
            HumanEntity.player.virtualArsenal.Clear();

            Weapon virtCladI = new Weapon("CLAD-I")
            {
                damage = 10,
                description = "Combat Lifeline Additional Defense Pistol, Generation I.",
                type = Weapon.WeaponType.Pistol,
                typeSkill = Weapon.SkillType.OneHandFirearms
            };

            Weapon virtCladII = new Weapon("CLAD-II")
            {
                damage = 14,
                description = "Combat Lifeline Additional Defense Pistol, Generation II.",
                type = Weapon.WeaponType.Pistol,
                typeSkill = Weapon.SkillType.OneHandFirearms
            };

            Weapon virtBucky = new Weapon("Bucky Shotgun")
            {
                damage = 20,
                description = "Named after the famed 'buckshot' of the 21st century. Standard home defence weapon.",
                type = Weapon.WeaponType.Shotgun,
                typeSkill = Weapon.SkillType.TwoHandFirearms
            };

            Weapon virtRAR = new Weapon("R-AR")
            {
                damage = 24,
                description = "Rapid-Assault Rifle. Exclusively used by the military and armed police.",
                type = Weapon.WeaponType.Rifle,
                typeSkill = Weapon.SkillType.TwoHandFirearms
            };

            shootingRangeArsenal.Add(virtCladI);
            shootingRangeArsenal.Add(virtCladII);
            shootingRangeArsenal.Add(virtBucky);
            shootingRangeArsenal.Add(virtRAR);
        }

        /// <summary>
        /// Print range inventory and get player to choose a weapon to shoot.
        /// </summary>
        /// <returns>Weapon to shoot.</returns>
        public Weapon ChooseRangeWeapon()
        {
            if (shootingRangeArsenal.Count == 0)
            {
                return null;
            }

            Utils.LbL("\n## WEAPON RACK ##", ConsoleColor.DarkGreen, 1, speedCustom: true);
            int listNum = 1;
            foreach (Weapon weapon in shootingRangeArsenal)
            {
                Utils.LbL($"\n{listNum++}. {weapon}\n{weapon.description}", ConsoleColor.Green, 1, speedCustom: true);
            }
            
            while (true)
            {
                Utils.LbL("\nChoose your weapon. (#)");

                int.TryParse(Utils.GetInput(), out int inputNum);
                if (0 < inputNum && inputNum <= shootingRangeArsenal.Count)
                {
                    return shootingRangeArsenal[inputNum - 1];
                }
                else
                {
                    Utils.LbL("\nInput a valid number.");
                }
            }
        }
        
        /// <summary>
        /// Print targets on the range and get player to choose one to shoot at.
        /// </summary>
        /// <returns></returns>
        public TargetEntity ChooseTarget()
        {
            if (targets.Count == 0)
            {
                return null;
            }

            Utils.LbL("\n---> TARGET ACQUISITION <---", ConsoleColor.DarkRed);
            int listNum = 1;
            foreach (TargetEntity target in targets)
            {
                Utils.LbL($"\n{listNum++}. {target.name}", ConsoleColor.Red);
            }

            while (true)
            {
                Utils.LbL("\nChoose your target. (#)");

                int.TryParse(Utils.GetInput(), out int inputNum);
                if (0 < inputNum && inputNum <= targets.Count)
                {
                    Console.WriteLine();
                    return targets[inputNum - 1];
                }
                else
                {
                    Utils.LbL("\nInput a valid number.");
                }
            }
        }

        /// <summary>
        /// Print all target body parts and get player to choose one to attack.
        /// </summary>
        /// <param name="target">Target acquired in ChooseTarget().</param>
        /// <returns>Body part to fire at.</returns>
        public BodyPartData ChooseBodyPart(Weapon weapon, TargetEntity target)
        {
            if (target.bodyParts.Count == 0)
            {
                return null;
            }

            Utils.LbL("\n===> BODY PART ACQUISITION <===", ConsoleColor.DarkRed);
            int listNum = 1;
            int skillMod = HumanEntity.player.skills.Find(x => x.name == Weapon.GetWeaponSkill(weapon).name).level;
            foreach (BodyPartData bodyPart in target.bodyParts)
            {
                int hitChance = bodyPart.baseHitChance + skillMod;
                if (hitChance > 100)
                {
                    hitChance = 100;
                }
                Utils.LbL($"\n{listNum++}. {bodyPart.name}: {bodyPart.baseHitChance + skillMod}% hit chance.", ConsoleColor.Red);
            }

            while (true)
            {
                Utils.LbL("\nChoose your target. (#)");

                int.TryParse(Utils.GetInput(), out int inputNum);
                if (0 < inputNum && inputNum <= targets.Count)
                {
                    return target.bodyParts[inputNum - 1];
                }
                else
                {
                    Utils.LbL("\nInput a valid number.");
                }
            }
        }

        /// <summary>
        /// Attempt to shoot the range target, implementing modifiers from character.
        /// </summary>
        /// <param name="weapon">Weapon character is firing.</param>
        /// <param name="target">Target being shot.</param>
        /// <param name="bodyPart">Body part of target being shot.</param>
        public void AttemptShot(Weapon weapon, TargetEntity target, BodyPartData bodyPart)
        {
            int attemptAttack = new Random().Next(0, 101);
            if (attemptAttack <= bodyPart.baseHitChance + Weapon.GetWeaponSkill(weapon).level)
            {
                bodyPart.health -= weapon.damage;
                if (bodyPart.health <= 0)
                {
                    bodyPart.health = 0;
                }
                Utils.LbL($"\n{target.name} struck in {bodyPart.name} for {weapon.damage} damage.");
            }
            else
            {
                Console.WriteLine("\nShot missed.");
            }
        }

        /// <summary>
        /// Assign targets and practing shooting them. Essentially,
        /// intro to weapon combat and target acquisition.
        /// </summary>
        public bool OnRange()
        {
            Weapon chosenWeapon = ChooseRangeWeapon();
            HumanEntity.player.virtualArsenal.Add(chosenWeapon);
            TargetEntity target = ChooseTarget();
            BodyPartData chosenBodyPart = ChooseBodyPart(chosenWeapon, target);
            AttemptShot(chosenWeapon, target, chosenBodyPart);
            target.EntityStatus();
            if (target.isDead)
            {
                Console.WriteLine($"\nRemoving {target.name} from the range.");
                targets.Remove(target);
            }
            return Utils.InputVerification("\nDo you want to remain on range? (y/n)");
        }
    }
}
