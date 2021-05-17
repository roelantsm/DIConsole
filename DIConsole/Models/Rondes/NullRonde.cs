using GanzenBoardGame.Application.Modals;
using GanzenBoardGame.Application.Modals.Rondes;
using System;
using System.Collections.Generic;
using System.Text;

namespace GanzenBoardGame.Application.Modals.Rondes
{
    public class NullRonde : Ronde
    {

        public NullRonde()
        {

        }

        public override int GooiDobbelStenen()
        {
            throw new NotImplementedException();
        }
    }
}
