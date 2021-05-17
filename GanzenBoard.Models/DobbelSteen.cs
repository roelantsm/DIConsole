using System;
using System.Collections.Generic;
using System.Text;

namespace GanzenBord2.Models
{
    public class DobbelSteen
    {
        readonly static int minAantal = 1;
        readonly static  int maxAantal = 6;

        public static int SimulateThrow()
        {
            return new Random().Next(minAantal, maxAantal + 1);
        }
    }
}
