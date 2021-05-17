using System;
using System.Collections.Generic;
using System.Text;
using GanzenBoardGame.Application.Logging;


namespace GanzenBoardGame.Application.Modals.Locations
{
    public class InnLocatie : Location
    {
        public const int InnLocation = 19;

        public InnLocatie(int pspelersVak) : base()
        {
            SpelersVak = pspelersVak;
        }

        public override Player OpDezeSoortLocatieAangekomen(Player speler, GanzenBoard ganzenBoard)
        {
            Console.WriteLine("Op special location Inn: 1 turn geen beurt");
            speler.turnsToSkip = speler.turnsToSkip + 1;
            return speler;
            // Skip one turn
        }
    }
}
