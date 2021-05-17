using System;
using System.Collections.Generic;
using System.Text;
using GanzenBoardGame.Application.Logging;


namespace GanzenBoardGame.Application.Modals.Locations
{
    public class EndLocatie : Location
    {

        public const int EndLocation = 63;

        public EndLocatie(int pspelersVak) : base()
        {
            SpelersVak = pspelersVak;
        }

        public override Player OpDezeSoortLocatieAangekomen(Player speler, GanzenBoard ganzenBoard)
        {
            Console.WriteLine($"Game ended, {speler.Name} wint");
            return speler;
            // The first player who arrives here, wins the game
        }
    }
}
