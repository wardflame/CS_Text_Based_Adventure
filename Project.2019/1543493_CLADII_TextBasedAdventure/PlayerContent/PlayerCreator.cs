using CLADII_TextBasedAdventure.EntityContent;
using System;
using System.Collections.Generic;
using System.Text;

namespace CLADII_TextBasedAdventure.PlayerContent
{
    public static class PlayerCreator
    {
        public static HumanEntity CreatePlayer()
        {
            HumanEntity playerToReturn = new HumanEntity("Prot2");
            Utils.LbL(@"Looking over your shoulder at the crowd being shoved about behind you,
you climb up into the bus and run your wrist over the pay scanner.

    Two seconds, 
    green check,
    and you're tucked away on one of the back seats, peeking out the window.

    Four men, tattooed and openly carrying pistols, look around frantically,
pushing panicked civs away. They split up, going for a bus each, but just as
a burly one can come up to your bus, the driver shuts his door and pulls off
from the depot, despite the burly man's attempts to bang on the bus' side.

    Looking out the back window, you watch the men reconvene, frustrated and
departing the depot. For the first time in the last forty-eight hours, you can
sit down and breathe...");
            return playerToReturn;
        }
    }
}
