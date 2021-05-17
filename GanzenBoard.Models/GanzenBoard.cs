using System;
using System.Collections.Generic;
using System.Text;

namespace GanzenBord2.Models
{
    public class GanzenBoard
    {
        public CasualLocatie StartPositie { get; set; }
        public CasualLocatie EindPositie { get; set; }
        public List<CasualLocatie> Spelboardvakjes { get; set; }
    }
}
