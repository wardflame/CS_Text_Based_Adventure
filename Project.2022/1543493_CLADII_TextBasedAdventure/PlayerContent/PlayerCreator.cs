using CLADII_TextBasedAdventure.BackEndContent;
using CLADII_TextBasedAdventure.EntityContent;
using System;
using System.Collections.Generic;
using System.Text;

namespace CLADII_TextBasedAdventure.PlayerContent
{
    public static class PlayerCreator
    {
        /// <summary>
        /// Serves as both the narrative intro and the character creator.
        /// Story begins in media res, with player narrowly escaping enemies.
        /// Player then recalls information from the last days which establishes
        /// their character's statistics.
        /// </summary>
        public static void CreateCharacter()
        {
            Utils.LbL(@"
Looking over your shoulder at the crowd being shoved around behind you,
you climb up into the bus and run your wrist over the pay scanner.

    Two seconds,
    three seconds,
    payment successful.

    You tuck away into one of the back seats and peek out a side window.

    Four men, tattooed and openly carrying pistols, look around frantically,
pushing panicked civs away. They split up, going for a bus each, but just as
a burly one can come up to your bus, the driver shuts his door and pulls off
from the depot, despite the goon's attempts to bang on the bus' side.

    Looking out the back window, you watch the men reconvene, frustrated and
arguing.

    It's over...

    For the first time in the last forty-eight hours, you can
sit down and ", newLine: false);
            Utils.LbL("breathe...\n", ConsoleColor.Cyan);
            Utils.LbL(@"
    You sit, panting, watching City 12 and all its neon lights and high-rises
growing smaller and smaller. Ahead of you, there's an open road, dust and dunes
for miles around, and only a few lonely travellers on the bus. It takes about
ten minutes for the dust and rocks to get boring to look at, at which point
you hoist the duffel bag you brought with you up onto your lap.
    
    Looking at the duffel bag makes you feel sick to your core. Not five hours
ago, Sonny, your closest friend, caught a few rounds in his torso and buckled
there and then. He told you to run for the depot, to run and not look back.
You did as he said. You left him there, alive, with those...monsters. But it's
what he wanted.

    'Can't be goin' to City 11 with these names,' Sonny said to you yesterday.
'Gotta shake it up, start fresh.' Thinking back on it makes you realise that
you really do need to thing about it now--the sooner the better. Don't want
any of these bus-goers reading into you too much.

    You reach into the duffel bag and pull out a MemStik, the standard
'flash-drive' of the modern world, wireless, syncs up with your CortexCore,
the chip in your brain, and gives you access to whatever's on the Mem, as it's
often called.
    
    You bring the Mem up to your temple and take a deep breath. It takes a few
moments, but Sonny's NewMe.exe boots up. It makes you smirk. The guy was
always into his theatrics... He's called you 'The Protagonist,' but it's only
a placeholder. Funny guy...
");
            Utils.LbL(@"
█▄░█ █▀▀ █░█░█ █▀▄▀█ █▀▀ ░ █▀▀ ▀▄▀ █▀▀
█░▀█ ██▄ ▀▄▀▄▀ █░▀░█ ██▄ ▄ ██▄ █░█ ██▄", ConsoleColor.Magenta, speed: 1, speedCustom: true);

            SetCharacterName();
            SetCharacterAge();

            Console.ReadKey();
        }

        /// <summary>
        /// Get a player input and verify that it will be the character's name.
        /// </summary>
        public static void SetCharacterName()
        {
            bool choosingName = true;
            while (choosingName)
            {
                Utils.LbL("\nInput your new name: ", ConsoleColor.Magenta, newLine: false);

                string input = Utils.GetInput();
                if (Utils.InputVerification($"\nAre you sure {input} will be your new name? (y/n)"))
                {
                    HumanEntity.player.name = input;
                    break;
                }
            }
        }

        /// <summary>
        /// Get a player input and verify that it will be the character's age.
        /// </summary>
        public static void SetCharacterAge()
        {
            bool choosingAge = true;
            while (choosingAge)
            {
                Utils.LbL("\nInput your new age: ", ConsoleColor.Magenta, newLine: false);

                string input = Utils.GetInput();
                if (int.TryParse(input, out int inputNum) && inputNum < 50 && inputNum >= 18 && Utils.InputVerification($"\nAre you sure {inputNum} will be your new age? (y/n)"))
                {
                    HumanEntity.player.age = inputNum;
                    break;
                }
                else
                {
                    Utils.LbL("\nInvalid age.", ConsoleColor.DarkMagenta);
                }
                Console.WriteLine();
            }
        }

        public static void SetCharacterProfession()
        {

        }
    }
}
