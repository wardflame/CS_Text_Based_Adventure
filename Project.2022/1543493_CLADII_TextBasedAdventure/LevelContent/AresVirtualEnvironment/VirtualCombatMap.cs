using CLADII_TextBasedAdventure.EntityContent.EntityTypes;
using CLADII_TextBasedAdventure.LevelContent.AresVirtualEnvironment.VirtualShootingRange;
using CLADII_TextBasedAdventure.UserInterfaceContent;
using System;
using System.Collections.Generic;
using System.Text;

namespace CLADII_TextBasedAdventure.LevelContent.AresVirtualEnvironment
{
    public class VirtualCombatMap : Map
    {
        public static bool firstVisit = true;
        public VirtualShootingRangeMap virtualShootingRangeMap = new VirtualShootingRangeMap();

        public VirtualCombatMap() : base("Virtual Combat Environment", Location.AresVirtualCombatEnvironment)
        {
            virtualShootingRangeMap = AddMap(new VirtualShootingRangeMap());
        }

        public override void OnEnterFirst()
        {
            CyberTechBanners.AresCombatBanner();

            Utils.LbL(@"
Lines trace a dark, milky-gray world for unending lengths in every direction.
Close by, some of those lines begin to flex to make shapes, growing and bending
until they make out a simple house, rectangular with no features or texture,
just lines, grid-like, and some hollow regions, windows, no doubt.
");
            Utils.LbL(@"    'Where the HELL you been, private?!'", ConsoleColor.Red, newLine: false);
            Utils.LbL(@" you hear coming from behind. A drill sergeant,
with one of those typical hats that covers their eyes, comes storming over
to you. He stands right up in your face, as they always do, and waits, breathing
intensely, for an answer.
");

            Utils.LbL($@"   [{HumanEntity.player.name}]", ConsoleColor.Yellow);
            Utils.LbL(@"    1. [QUESTION] Who are you?");
            Utils.LbL(@"    2. [QUESTION] Where are we?");
            Utils.LbL(@"    3. [PLAY ALONG] Was tying my boots, sir!");

            bool queryPlayer = true;
            while (queryPlayer)
            {
                string input = Utils.GetInput(trim: true);
                switch (input)
                {
                    case "1":
                        {
                            Utils.LbL(@"
    'You not heard, kid? I'm the toughest motherfucker you'll meet. I'm Drill Sergeant Jones. Now, move, move, move!'", ConsoleColor.Red);
                            queryPlayer = false;
                        }
                        break;
                    case "2":
                        {
                            Utils.LbL(@"
    'You're in Drill Sergeant Jones' slaughterhouse now, kid! Get moving!'", ConsoleColor.Red);
                            queryPlayer = false;
                        }
                        break;
                    case "3":
                        {
                            Utils.LbL(@"    
    'Are you a child, private?! Drill Sergeant Jones gon' show you how to tie those laces, kid! Get moving!'", ConsoleColor.Red);
                            queryPlayer = false;
                        }
                        break;
                    default:
                        {
                            Utils.LbL(@"
    Invalid response.", ConsoleColor.DarkGray);
                        }
                        break;
                }
            }

            Utils.LbL(@"
    Drill Sergeant Jones takes a firm grip of your shirt and pulls you along in a 
run towards the building that formed earlier. However, another area has formed,
a gazebo with benches and racks beneath it. Beyond the gazebo, standing targets
dot the horizon, all of them grid-like and milky-gray, brighter in their centre.
");
        }
    }
}
