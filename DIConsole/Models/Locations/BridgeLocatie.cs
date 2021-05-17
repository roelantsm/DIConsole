using GanzenBoardGame.Application.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace GanzenBoardGame.Application.Modals.Locations
{
    public class BridgeLocatie : Location
    {
        public int BridgeLocationToGo = 12;

        public const int BridgeLocation = 6;

        public BridgeLocatie(int pspelersVak) : base()
        {
            SpelersVak = pspelersVak;
        }

        public override Player OpDezeSoortLocatieAangekomen(Player speler, GanzenBoard ganzenBoard)
        {
            // Go to 12
            Console.WriteLine("Op special location Brug: ga naar vak 12");
            speler.Pion.Locatie = ganzenBoard.Spelboardvakjes.Where(x => x.SpelersVak == BridgeLocationToGo).First();
            return speler;
        }
    }
}
