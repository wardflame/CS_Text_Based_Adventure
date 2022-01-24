using CLADII_TextBasedAdventure.BackEndContent;
using CLADII_TextBasedAdventure.CombatContent;
using CLADII_TextBasedAdventure.EntityContent;
using CLADII_TextBasedAdventure.EntityContent.EntityTypes;
using CLADII_TextBasedAdventure.UserInterfaceContent;
using System;
using System.Collections.Generic;
using System.Text;

namespace CLADII_TextBasedAdventure.PlayerContent
{
    public static class PlayerCreator
    {
        /// <summary>
        /// Run the player through a series of queries to gather essential
        /// information about them: Name, Age, Body Type and Skills. Done
        /// through the guise of a bit of in-lore neural software.
        /// </summary>
        public static void CreateCharacter()
        {
            CyberTechBanners.NewMeBanner();
            SetCharacterName();
            SetCharacterAge();
            SetCharacterBodyType();
            SetCharacterSkills();

            Utils.LbL("\nWelcome to the new you, hun.", ConsoleColor.Magenta);
        }

        /// <summary>
        /// Get a player input and verify that it will be the character's name.
        /// </summary>
        private static void SetCharacterName()
        {
            bool choosingName = true;
            while (choosingName)
            {
                Utils.LbL("\nInput your new name: ", ConsoleColor.Magenta, newLine: false);

                string input = Utils.GetInput();
                if (Utils.InputVerification($"\nWanna be called {input}? (y/n)"))
                {
                    HumanEntity.player.name = input;
                    choosingName = false;
                }
                continue;
            }
        }

        /// <summary>
        /// Get a player input and verify that it will be the character's age.
        /// </summary>
        private static void SetCharacterAge()
        {
            bool choosingAge = true;
            while (choosingAge)
            {
                Utils.LbL("\nInput your new age: ", ConsoleColor.Magenta, newLine: false);

                string input = Utils.GetInput();
                int.TryParse(input, out int inputNum);
                if (18 <= inputNum && inputNum <= 50)
                {
                    if (Utils.InputVerification($"\nSure you wanna be {inputNum} years old? (y/n)"))
                    {
                        HumanEntity.player.age = inputNum;
                        choosingAge = false;
                    }
                }
                else if (inputNum > 50)
                {
                    Utils.LbL("\nYou wouldn't have made it this far at that age, babe.", ConsoleColor.DarkMagenta);
                }
                else if (0 < inputNum && inputNum < 18)
                {
                    Utils.LbL("\nLittle young, doncha think?", ConsoleColor.DarkMagenta);
                }
                else
                {
                    Utils.LbL("\nInput correct age.", ConsoleColor.DarkMagenta);
                }
                continue;
            }
        }

        /// <summary>
        /// Get a player input and verify they want their body type to be as
        /// designated.
        /// </summary>
        private static void SetCharacterBodyType()
        {
            bool choosingBodyType = true;
            while (choosingBodyType)
            {
                Utils.LbL("\nChoose your body type:\n", ConsoleColor.Magenta);
                int listNum = 1;
                var bodyEnums = Enum.GetValues(typeof(HumanEntity.BodyType));
                foreach (HumanEntity.BodyType bodyType in bodyEnums)
                {
                    Utils.LbL($"{listNum++}. {bodyType}");
                }

                string input = Utils.GetInput(trim: true);
                int.TryParse(input, out int inputNum);
                if (1 <= inputNum && inputNum <= Enum.GetNames(typeof(HumanEntity.BodyType)).Length)
                {
                    if (Utils.InputVerification($"\nWanna be body type {(HumanEntity.BodyType)inputNum - 1}? (y/n)"))
                    {
                        HumanEntity.player.bodyType = (HumanEntity.BodyType)inputNum - 1;
                        choosingBodyType = false;
                    }
                    continue;                  
                }
                else
                {
                    Utils.LbL("\nInput appropriate number.", ConsoleColor.DarkMagenta);
                }
            }
        }

        /// <summary>
        /// Introduce the player to skills and skill storage allocation,
        /// then have them choose to add skill points to skills they're
        /// interested in. 
        /// </summary>
        private static void SetCharacterSkills()
        {
            bool choosingProfession = true;
            while (choosingProfession)
            {
                Utils.LbL($"\nWelcome to the Build-a-Bitch section of the program, {HumanEntity.player.name}. Here's your chance to" +
                    $"\nstart fresh. I've listed all the skills you can develop here. Each of these" +
                    $"\nskills will benefit you in countless different situations. They'll get you out" +
                    $"\nof trouble, and might get you into it.\n" +
                    $"" +
                    $"\nWe're uploading memories here, experiences and data from real-world examples." +
                    $"\nIt takes a huge load of data to set that up, y'know. The human brain stores 2.5" +
                    $"\npetabytes of data. Your MemStik gives you another 0.5, so you're at 3. Below," +
                    $"\nyou can select a skill by its number and add/remove storage allocation for it. The" +
                    $"\nmore allocation you give to a skill, the better you'll be at it.\n", ConsoleColor.DarkMagenta, newLine: false);
                Utils.LbL("\nNOTE: ", ConsoleColor.Red, newLine: false);
                Utils.LbL("1 skill partition is about 0.06 petabytes (60 Terabytes!), so you got" +
                    "\nroughly 50 partitions to play with. CHOOSE WISELY!!!", ConsoleColor.DarkMagenta);

                int pointsToSpend = 50;
                while (true)
                {
                    float petabytesRemaining = 0.06f*(float)pointsToSpend;
                    Utils.LbL($"\n[## SKILLS ##]", ConsoleColor.Magenta, 1, speedCustom: true);
                    Utils.LbL($"Petabytes remaining: {petabytesRemaining}", ConsoleColor.Cyan, 1, speedCustom: true);

                    int listEnd = Skill.PrintPCSkills();

                    if (pointsToSpend <= 0)
                    {
                        Utils.LbL($"\n{listEnd}. Finish assigning skills.", ConsoleColor.Yellow, 1, speedCustom: true);
                    }

                    string input = Utils.GetInput(trim: true);
                    int.TryParse(input, out int inputNum);
                    if (pointsToSpend <= 0 && inputNum == listEnd )
                    {
                        if (Utils.InputVerification("\nAre you sure you're finished setting your skills? (y/n)"))
                        {
                            choosingProfession = false;
                            break;
                        }
                        continue;
                    }
                    else if (0 < inputNum && (inputNum - 1) <= HumanEntity.player.skills.Count)
                    {
                        Skill chosenSkill = HumanEntity.player.skills[inputNum - 1];
                        int pointsToChange = InputPCSkills(pointsToSpend, chosenSkill.level, chosenSkill.name);
                        chosenSkill.level += pointsToChange;
                        pointsToSpend -= pointsToChange;
                    }                    
                    else
                    {
                        Utils.LbL("\nInvalid number.\n", ConsoleColor.DarkMagenta);
                    }
                }                
            }
        }

        /// <summary>
        /// Feed in points remaining to be spent on skills, followed by the current
        /// level of the targetted skill and the name. Request a modification from
        /// the player and apply that number to the skill level/reduce from the 
        /// point remaining int.
        /// </summary>
        /// <param name="pointsRemaining">Remaining points to be spent.</param>
        /// <param name="currentSkillLevel">Level of targetted skill.</param>
        /// <param name="skillName">Name of targetted skill.</param>
        /// <returns></returns>
        private static int InputPCSkills(int pointsRemaining, int currentSkillLevel, string skillName)
        {
            Utils.LbL($"\nHow many points do you want to add/remove from ", ConsoleColor.Magenta, newLine: false);
            Utils.LbL($"{skillName}", ConsoleColor.Blue, newLine: false);
            Utils.LbL($"?", ConsoleColor.Magenta);

            string input = Utils.GetInput(trim: true);

            if (!int.TryParse(input, out int pointsToChange))
            {
                Console.WriteLine("\nPlease input a number.");
                return InputPCSkills(pointsRemaining, currentSkillLevel, skillName);
            }

            if (pointsRemaining < pointsToChange)
            {
                Console.WriteLine($"\nYou have insufficient points to spend.");
                return InputPCSkills(pointsRemaining, currentSkillLevel, skillName);
            }

            if ((currentSkillLevel + pointsToChange) > 100)
            {
                Console.WriteLine($"Skill level cannot exceed 100.");
                return InputPCSkills(pointsRemaining, currentSkillLevel, skillName);
            }

            if (currentSkillLevel < Math.Abs(pointsToChange) && (pointsToChange < 0))
            {
                Console.WriteLine($"\nYou cannot remove that many points.");
                return InputPCSkills(pointsRemaining, currentSkillLevel, skillName);
            }

            return pointsToChange;
        }

        /// <summary>
        /// Create a new inventory for the player depending on the
        /// difficult they choose to start the game on.
        /// </summary>
        private static void InitPCInventory(int diffcultyNum)
        {
            switch (diffcultyNum)
            {
                case 1:
                    {

                    }
                    break;
                case 2:
                    {

                    }
                    break;
                case 3:
                    {

                    }
                    break;
                default:
                    {
                        Utils.LbL("\nInput a valid number.");
                    }
                    break;
            }
        }
    }
}
