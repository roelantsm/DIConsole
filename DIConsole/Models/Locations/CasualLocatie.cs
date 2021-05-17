using System;
using System.Collections.Generic;
using System.Text;
using GanzenBoardGame.Application.Logging;


namespace GanzenBoardGame.Application.Modals.Locations
{
    public class CasualLocatie : Location
    {

        public CasualLocatie(int position, bool pisSpaceWithGoose) : base()
        {
            IsSpaceWithGoose = pisSpaceWithGoose;
            SpelersVak = position;
        }
        
        public CasualLocatie()
        {
                
        }

        public CasualLocatie(int pspelersVak) : base()
        {
            SpelersVak = pspelersVak;
        }

        public override Player OpDezeSoortLocatieAangekomen(Player speler, GanzenBoard ganzenBoard)
        {
            return speler;
            // Go to 12
        }
    }
}