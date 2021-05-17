using GanzenBoardGame.Application.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace GanzenBoardGame.Application.Modals.Rondes
{
    public class CasualRonde : Ronde
    {

        public CasualRonde()
        {
        }

        public CasualRonde(int ronde)
        {
            CurrentRonde = ronde;
        }

        public override int GooiDobbelStenen()
        {
            var geworpen = Tuple.Create(DobbelSteen.SimulateThrow(), DobbelSteen.SimulateThrow());
            return geworpen.Item1 + geworpen.Item2;
        }
    }
}
