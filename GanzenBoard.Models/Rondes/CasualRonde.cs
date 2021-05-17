using GanzenBord2.Models.Rondes;
using System;
using System.Collections.Generic;
using System.Text;

namespace GanzenBord2.Models
{
    public class CasualRonde : Ronde
    {
        //public void StartNewRonde(List<Player> spelers)
        //{
        //    for (int i = 0; i < spelers.Count; i++)
        //    {
        //        int SpelersGeworpenAantalDezeRonde = 0;
        //        for (int j = 0; j < aantalWorpenPerBeurt; j++)
        //        {
        //            SpelersGeworpenAantalDezeRonde += DobbelSteen.SimulateThrow();
        //        }
        //    }
        //}

        public override void StartNewRonde(List<Player> spelers)
        {
            throw new NotImplementedException();
        }
    }
}
