using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GanzenBoardGame.Application.Logging;


namespace GanzenBoardGame.Application.Modals.Locations
{
    public class MazeLocatie : Location
    {
        public int DeathLocationToGo = 39;
        public const int MazeLocation = 42;

        public MazeLocatie(int pspelersVak) : base()
        {
            SpelersVak = pspelersVak;
        }

        public override Player OpDezeSoortLocatieAangekomen(Player speler, GanzenBoard ganzenBoard)
        {
            Console.WriteLine("Op special location Maze: ga naar 39");
            speler.Pion.Locatie = ganzenBoard.Spelboardvakjes.Where(x => x.SpelersVak == DeathLocationToGo).First();
            // Go back to 39
            return speler;
        }
    }
}
