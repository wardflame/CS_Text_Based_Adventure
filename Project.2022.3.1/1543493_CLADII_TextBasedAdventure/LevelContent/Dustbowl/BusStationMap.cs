using CLADII_TextBasedAdventure.PlayerContent;
using System;
using System.Collections.Generic;
using System.Text;

namespace CLADII_TextBasedAdventure.LevelContent.Dustbowl
{
    public class BusStationMap : Map
    {
        public static bool busStationIntro = true;
        public BusStationMap() : base("Bus Station", Location.BusStation)
        {
        }

        public override void OnEnterFirst()
        {
            Utils.LbL(@"
A sudden pressure jolts you awake. An elderly fellow stands over you, kind-faced and weathered.
");
            Utils.LbL(@"    [Old Man]", ConsoleColor.Yellow);
            Utils.LbL(@"    'Sorry to bother ya, slick, but this is the end of the line. Bus don't go no futher
into C-11 territory. You'll have to get off here, at Dustbowl. Next bus to pick up
yous peoples will be either tonight or tomorrow mornin'. Sorry 'bout that.");
            Utils.LbL(@"    [/Old Man]", ConsoleColor.Yellow);

            Utils.LbL(@"
    The old man departs before you can reply, so, instead, you tuck away that MemStik,
zip up the duffel and hoist yourself out of the set. Your mind is foggy and the
distant sound of gunshots ring in your mind. But all is wiped away as you take your
first step off the bus, into a sun falling behind the arid horizon, leaving you, free,
to make a fresh start in the twilight.
");
        }
    }
}
