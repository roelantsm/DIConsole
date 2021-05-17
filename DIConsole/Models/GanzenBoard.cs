using GanzenBoardGame.Application.Modals.Locations;
using System;
using System.Collections.Generic;
using System.Text;

namespace GanzenBoardGame.Application.Modals
{
    public class GanzenBoard
    {
        public int StartPositie { get; set; }
        // public static int EindPositie { get; set; } = 64;
        public static int AantalValkjes { get; set; } = 63;
        public List<Location> Spelboardvakjes { get; set; } = new List<Location>();
    }
}
