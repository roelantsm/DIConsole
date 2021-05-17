using System;
using System.Collections.Generic;
using System.Text;

namespace GanzenBord2.Models.Rondes
{
    public abstract class Ronde
    {
        public static int AantalKeerGooienPerBeurt = 2;

        public abstract void StartNewRonde(List<Player> spelers);
    }
}
