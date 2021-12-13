using CLADII_TextBasedAdventure.EntityContent.EntityTypes;
using CLADII_TextBasedAdventure.LevelContent.AresVirtualEnvironment;
using CLADII_TextBasedAdventure.PlayerContent;
using CLADII_TextBasedAdventure.SaveSystem;
using System;
using System.Collections.Generic;
using System.Text;

namespace CLADII_TextBasedAdventure.LevelContent.IntroBus
{
    public class IntroBusMap : Map
    {
        public VirtualCombatMap virtualCombatMap = new VirtualCombatMap();
        public IntroBusMap() : base("The Intro Bus", Location.IntroBus)
        {
            virtualCombatMap = AddMap(new VirtualCombatMap());
        }

        /// <summary>
        /// Introduction method to the virtual combat environment,
        /// and area the player can access from the menu to test out
        /// weapons etc.
        /// </summary>
        public override void OnEnterFirst()
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
you really do need to think about it now--the sooner the better. Don't want
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

            PlayerCreator.CreateCharacter();

            Utils.LbL(@"
    Your head feels a little fuzzy, but when you come around from Sonny's software,
you spend a brief time looking out the window at the dusty lands beyond. When
you bring up your Glancer, or Glance Profile, it's different, truly the new you:");

            Utils.LbL(@"
█████▀███████████████████████████████████████
█─▄▄▄▄█▄─▄████▀▄─██▄─▀█▄─▄█─▄▄▄─█▄─▄▄─█▄─▄▄▀█
█─██▄─██─██▀██─▀─███─█▄▀─██─███▀██─▄█▀██─▄─▄█
▀▄▄▄▄▄▀▄▄▄▄▄▀▄▄▀▄▄▀▄▄▄▀▀▄▄▀▄▄▄▄▄▀▄▄▄▄▄▀▄▄▀▄▄▀", ConsoleColor.Cyan, 1, speedCustom: true);
            Utils.LbL($"\nName: {HumanEntity.player.name}" +
                $"\nAge: {HumanEntity.player.age}" +
                $"\nBody Type: {HumanEntity.player.bodyType}", ConsoleColor.Cyan);

            Utils.LbL(@"
    You switch off your personal HUD and lean back into your chair. As you get comfortable,
you feel something hard in your back pocket. You finger it out and hold it up. It's
a Mem, yes, but it's not like the other one you had, and not like any other you've seen.
In Sonny fashion, there's a bit of tape wrapped around the Mem, with his handwriting:
'With love, Sonny.'

    You bring the Mem to your temple and wait. For a few seconds, there's no response,
then, suddenly, the world goes dark...");

            Utils.ConsoleUp();
        }
    }
}
