using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GanzenBoardGame.Application.Logging;


namespace GanzenBoardGame.Application.Modals.Locations
{
    public class PrisonLocatie : Location
    {
        public int AantalTurnToSKip = 3;
        public const int PrisonLocation = 52;

        public PrisonLocatie(int pspelersVak) : base()
        {
            SpelersVak = pspelersVak;
        }

        public override Player OpDezeSoortLocatieAangekomen(Player speler, GanzenBoard ganzenBoard)
        {
            Console.WriteLine("Op special location Prizon: sla 3 beurten over");
            for (int i = 0; i < AantalTurnToSKip; i++)
            {
                speler.turnsToSkip = speler.turnsToSkip + 1;
            }
            // Skip 3 turns
            return speler;
        }
    }
}
