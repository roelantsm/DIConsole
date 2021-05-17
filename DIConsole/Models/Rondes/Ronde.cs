using System;
using System.Collections.Generic;
using System.Text;

namespace GanzenBoardGame.Application.Modals.Rondes
{
    public abstract class Ronde
    {
        public int CurrentRonde { get; set; }
        public static int AantalKeerGooienPerBeurt = 2;

        public abstract int GooiDobbelStenen();
    }
}
