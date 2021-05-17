using System;
using System.Collections.Generic;
using System.Text;
using GanzenBoardGame.Application.Logging;


namespace GanzenBoardGame.Application.Modals.Locations
{
    public class NullLocation :Location
    {

        public NullLocation(int pspelersVak) : base()
        {
            SpelersVak = pspelersVak;
        }

        public NullLocation() : base()
        {
        }

        public override Player OpDezeSoortLocatieAangekomen(Player speler, GanzenBoard ganzenBoard)
        {
            throw new NotSupportedException();
        }
    }
}
