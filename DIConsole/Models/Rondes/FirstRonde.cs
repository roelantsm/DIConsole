using GanzenBoardGame.Application.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GanzenBoardGame.Application.Modals.Rondes
{
    public class FirstRonde : Ronde
    {

        public FirstRonde()
        {
        }

        public FirstRonde(int ronde)
        {
            CurrentRonde = ronde;
        }

        public override int GooiDobbelStenen()
        {
            var geworpen = Tuple.Create(DobbelSteen.SimulateThrow(), DobbelSteen.SimulateThrow());
            if (geworpen.Item1 == 5 && geworpen.Item2 == 4)
            {
                Console.WriteLine("5 en 4 geworpen");
                return 26;
            }
            else if (geworpen.Item1 == 6 && geworpen.Item2 == 3)
            {
                Console.WriteLine("6 en 3 geworpen");
                return 56;
            }
            else
                return geworpen.Item1 + geworpen.Item2;
        }
    }
}
