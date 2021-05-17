using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GanzenBoardGame.Application.Logging;


namespace GanzenBoardGame.Application.Modals.Locations
{
    public class DeathLocatie : Location
    {
        // TO DO 1 of 0
        public int DeathLocationToGo = 1;
        public const int DeathLocation = 58;

        public DeathLocatie(int pspelersVak) : base()
        {
            SpelersVak = pspelersVak;
        }

        public override Player OpDezeSoortLocatieAangekomen(Player speler, GanzenBoard ganzenBoard)
        {
            Console.WriteLine("Op special location Death: start/vak 1");
            speler.Pion.Locatie = ganzenBoard.Spelboardvakjes.Where(x => x.SpelersVak == DeathLocationToGo).First();
            return speler;
        }
        // Go back to start
    }
}
