using System;
using System.Collections.Generic;
using System.Text;
using GanzenBoardGame.Application.Logging;


namespace GanzenBoardGame.Application.Modals.Locations
{
    public class WellLocatie : Location
    {

        public const int WellLocation = 31;

        public WellLocatie(int pspelersVak) : base()
        {
            SpelersVak = pspelersVak;
        }

        public override Player OpDezeSoortLocatieAangekomen(Player speler, GanzenBoard ganzenBoardr)
        {
            Console.WriteLine("Op special location Well: nog te implementeren");
            //If you come here, you need to wait until another player arrives.  The one who was there first can continue playing
            return speler;
        }
    }
}
