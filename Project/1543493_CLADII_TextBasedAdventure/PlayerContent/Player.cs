using _1543493_CLADII_TextBasedAdventure.EntityContent;
using _1543493_CLADII_TextBasedAdventure.ItemContent;
using _1543493_CLADII_TextBasedAdventure.ProfessionContent;
using System;
using System.Collections.Generic;
using System.Text;

namespace _1543493_CLADII_TextBasedAdventure.PlayerContent
{
    public class Player
    {
        public string name;
        public int age;
        public Gender gender;
        public List<Skill> playerSkills = new List<Skill>();
        public Profession profession;
        public HumanEntity entity = new HumanEntity();
        public List<Item> equipped = new List<Item>();
        public List<Item> backpack = new List<Item>();

        public enum Gender
        {
            Male,
            Female,
            Other
        }

        public static Player CharacterCreator()
        {
            Player player = new Player();

            Console.Write("\nName?");
            player.name = Console.ReadLine();

            Console.Write("\nAge?");
            int.TryParse(Console.ReadLine(), out player.age);

            Console.Write($"\nGender?\n");
            Console.WriteLine(Gender.Male);
            Console.WriteLine(Gender.Female);
            Console.WriteLine(Gender.Other);
            string input = Console.ReadLine().ToLower().Trim();
            switch (input)
            {
                case "male":
                    {
                        player.gender = Gender.Male;
                    }
                    break;
                case "female":
                    {
                        player.gender = Gender.Female;
                    }
                    break;
                case "other":
                    {
                        player.gender = Gender.Other;
                    }
                    break;
            }

            player.playerSkills = Skill.CreateSkills();

            int num = 1;
            foreach (Skill skill in player.playerSkills)
            {
                if (skill.name == "Melee Combat")
                {
                    skill.level += 10;
                }
                Console.WriteLine($"\n{num}. {skill}");
                num++;
            }
            int.TryParse(Console.ReadLine(), out int inputInt);
            Skill desired = player.playerSkills[inputInt - 1];

            Console.WriteLine($"\n{desired}");

            Console.ReadKey();

            return player;
        }


    }
}
